using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Числовая заметка
    /// </summary>
    [DataContract]
    public class IntNote
    {
        int valueNumber = 0;

        /// <summary>
        /// Значение
        /// </summary>
        [DataMember]
        public int Value
        {
            get => valueNumber;
            set => valueNumber = value;
        }

        public IntNote Copy() => new IntNote()
        {
            Value = Value
        };


        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }



        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        public static void JsonWrite(object obj, Type type, string namefile)
        {
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            try
            {
                namefile = namefile.Replace('/', '\\');
                DataContractJsonSerializer json = new DataContractJsonSerializer(type);
                json.WriteObject(fileStream, obj);
                fileStream.Close();
            }
            catch (Exception e)
            {
                try
                {
                    fileStream.Close();
                }
                catch
                {

                }
                throw e;
            }

        }

        public void LoadJson(string jsonFile) => SetNote((IntNote)FileClass.JsonRead(jsonFile, GetType()));

        public virtual void SetNote(IntNote parameter)
        {
            Value = parameter.Value;
        }

        public static IntNote CreateFromJson(string jsonFile)
        {
            IntNote intNote = new IntNote();
            intNote.LoadJson(jsonFile);
            return intNote;
        }
    }
}
