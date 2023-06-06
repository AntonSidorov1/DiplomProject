using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace FileManegerJson
{
    [DataContract]
    public abstract class AbstractFileClass : IDisposable
    {
        DateTime dateCreate = DateTime.Now;

        public bool IsFileClass => this is FileClass;
        public FileClass AsFileClass => this as FileClass;

        /// <summary>
        /// Дата создания файла
        /// </summary>
        public DateTime DateCreate
        {
            get => dateCreate;
            set => dateCreate = value;
        }

        /// <summary>
        /// Текстовое значение даты создания
        /// </summary>
        [DataMember]
        public string DateCreateText
        {
            get => dateCreate.ToString("dd.MM.yyyy HH:mm:ss.fff");
            set
            {
                 DateTime dateCreate = Convert.ToDateTime(value);
                DateCreate = dateCreate;
                dateCreate = DateCreate;
            }
        }


        public AbstractFileClass()
        {
            ChangeIndexName();
        }

        protected string nameFile;
        public virtual string NameFile { get => nameFile; set => nameFile = value; }

        protected object tagObject = "";
        protected string tagString = "";
        protected int tagInt = 0;
        protected object tag = "";
        public object TagObject { get => tagObject; set => tagObject = value; }
        public string TagString { get => tagString; set => tagString = value; }
        public int TagInt { get => tagInt; set => tagInt = value; }
        public object Tag { get => tag; set => tag = value; }


        public ref object RefTagObject => ref tagObject;
        public ref string RefTagString => ref tagString;
        public ref int RefTagInt => ref tagInt;

        bool changeName = true;

        public bool ChangeName { get => changeName; set => changeName = value; }

        string indexFileName = "";

        public virtual string IndexNameFile => IndexFileName;

        /// <summary>
        /// Уникальное имя файла
        /// </summary>
        [DataMember]
        public string IndexFileName
        {
            get
            {
                ChangeIndexName();
                return indexFileName;
            }
            set
            {
                try
                {
                    ChangeIndexName(value);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public string DateTimeName => "File_" + DateCreateText.Replace('.', '-').Replace(':', '-').Replace(' ', '_');

        public abstract string IndexClassName { get; }

        public string ClassDateTimeName => IndexClassName + "_" + DateTimeName;

        public void ChangeIndexName(string fileName)
        {
            string index = fileName;
            try
            {
                char[] symwols = { '/', '\\', '|', '"', '\'', ':', '?', '*', '<', '>' };
                string symwolsText = String.Join(" ", symwols);
                for (int i = 0; i < symwols.Length; i++)
                {
                    if (index.Contains(symwols[i]))
                        throw new ArgumentException("Имя файла не может содержать символы " + symwolsText);
                }
                indexFileName = index;
            }
            catch (Exception ex)
            {

            }
            ChangeIndexName();
        }

        public static char[] Symwols = { '/', '\\', '|', '"', '\'', ':', '?', '*', '<', '>' };

        public virtual void ChangeIndexName()
        {
            try
            {
                string index = indexFileName;
                if (index == "" || index.Equals("") || index == null || index is null)
                    throw new ArgumentException("Имя файла не может быть пустым");

                char[] symwols = Symwols;
                string symwolsText = String.Join(" ", symwols);
                for (int i = 0; i < symwols.Length; i++)
                {
                    if (index.Contains(symwols[i]))
                        throw new ArgumentException("Имя файла не может содержать символы " + symwolsText);
                }
            }
            catch (Exception ex)
            {
                indexFileName = ClassDateTimeName;
                ChangeIndexName();
            }
        }

        public static explicit operator string(AbstractFileClass file) => file.IndexFileName;
         
        /// <summary>
        /// Свойство файла
        /// </summary>
        public virtual string PropertyOfFile
        {
            get
            {
                string property = $"Имя файла: {IndexFileName} \n" +
                    $"Дата создания файла: {DateCreateText}";


                return property;
            }
        }

        public void SetAbstractFile(AbstractFileClass file)
        {
            DateCreateText = file.DateCreateText;
            IndexFileName = file.IndexFileName;
            //NameFile = file.NameFile;
        }


        AbstractFileClass copyFile;

        protected PictureBox pictureBox;

        public PictureBox PictureBox
        {
            get => pictureBox;
            set => pictureBox = value;
        }


        public AbstractFileClass CopyFile
        {
            get => copyFile;
            set => copyFile = value;
        }

        public string PropertyOfCopyFile
        {
            get
            {
                try
                {
                    return CopyFile.PropertyOfFile;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string ReplaceNewLine(string text)
        {
            return text.Replace("\n", Environment.NewLine);
        }

        public string PropertyOfFileNewLine => ReplaceNewLine(PropertyOfFile);
        public string PropertyOfCopyFileNewLine => ReplaceNewLine(PropertyOfCopyFile);

        public virtual void FromFile(AbstractFileClass file)
        {
            SetAbstractFile(file);
        }

        public virtual void Dispose()
        {
            GC.Collect();
        }
    }
}
