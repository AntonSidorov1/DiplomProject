using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace FileManegerJson
{
    [DataContract]
    public abstract class FileClass : SecurityFile<FileClass, FolderClass>, ITagInfoClass<FileClass>
    {
        public bool IsDisk => this is DiskClass;
        public bool IsDisksFew => this is DisksFew;
        public bool IsDisksPart => this is DiskPartClass;
        public DiskClass AsDisk => this as DiskClass;
        public DisksFew AsDisksFew => this as DisksFew;
        public DiskPartClass AsDisksPart => this as DiskPartClass;

        public bool IsName => this is NameFile;
        public NameFile AsName => this as NameFile;

        public bool IsDataBase => this is DataBaseFile;
        public DataBaseFile AsDataBase => this as DataBaseFile;

        public bool IsProductParameter => this is ProductParameterFile;
        public ProductParameterFile AsProductParameter => this as ProductParameterFile;

        public bool IsOrganizaion => this is OrganizaionFile;
        public OrganizaionFile AsOrganizaion => this as OrganizaionFile;

        public bool IsSity => this is SityFile;
        public SityFile AsSity => this as SityFile;

        public bool IsTraidingPoint => this is TraidingPointFile;
        public TraidingPointFile AsTraidingPoint => this as TraidingPointFile;

        public bool IsStore => this is StoreFile;
        public StoreFile AsStore => this as StoreFile;

        public bool IsSupplier => this is SupplierFile;
        public SupplierFile AsSupplier => this as SupplierFile;

        public bool IsManufacture => this is ManufactureFile;
        public ManufactureFile AsManufacture => this as ManufactureFile;

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if(file is FileClass)
            {
                Name = (file as FileClass).Name;
                IndexFile = file.AsFileClass.IndexFile;
            }
        }

        public override string PropertyOfFile
        {
            get
            {
                string text = $"Тип файла: {FileType} \n" +
                    $"Индекс файла {Index} \n" +
                    $"Файловый индекс: {IndexFile} \n" +
                    "Имя: " + FileName + "\n" + base.PropertyOfFile + $"\n" +
            $"";
                string message = "";
                string path = StartupPathWithOutRoot("\\", out message);
                text += message + ": " + path + "\n";
                path = StartupPathWithRoot("\\", out message);
                text += message + ": " + path + "\n";
                path = FullPathWithOutRoot("\\", out message);
                text += message + ": " + path + "\n";
                path = FullPathWithRoot("\\", out message);
                text += message + ": " + path + "\n";
                path = StartupPathWithDisk("\\", out message);
                text += message + ": " + path + "\n";
                return text;
            }
        }
            

        protected string text = "";

        public const string DefaultName = "file";

        public FileClass() : base()
        {
            FileName = DefaultName;
            GetData();
            Create();
            CreateThisIndexFile();
        }

        protected virtual void Create()
        {

        }

        public FileClass(string name, bool file = true) : this()
        {
            if(file)
            {
                FileName = name;
            }
            else
            {
                Name = name;
            }
            
        }

        public FileClass(string name, string fileName) : this(fileName)
        {
            Name = name;
        }

        public virtual void GetData()
        {

        }

        public void SetTemporaryIndex(FileClass file)
        {
            TemporaryIndex = file.TemporaryIndex;
        }

        public virtual string Text1
        {
            get => text;
            set
            {
                try
                {
                    text = value;
                    string[] line = text.Split('/', '\\');
                    text = line[line.Length - 1];
                    NameFile = text;
                }
                catch (NullReferenceException e)
                {

                }
                catch (ArgumentNullException e)
                {

                }
                catch (ArgumentOutOfRangeException e)
                {

                }
                catch (ArgumentException e)
                {

                }
                catch (Exception e)
                {

                }
            }
        }

        public override string NameFile { 
            get => base.NameFile;
            set
            {
                base.NameFile = value;
                if (text != base.NameFile)
                    text = base.NameFile;
            }
        }

        //public delegate void FileContentOutput(FileClass file);

        public FileContentOutput NameOutput;


        public virtual void NameFileOutputRun()
        {
            try
            {
                NameFileOutput?.Invoke(this);
            }
            catch
            {

            }
        }


        public string Name
        {
            get => Text1;
            set
            {
                Text1 = value;
                try
                {
                    NameOutput(this);
                }
                catch
                {
                    
                }
            }
        }


        public virtual ref string RefName { get => ref text; }

        public bool IsText => this is TextFile;
        public TextFile AsText => this as TextFile;


        public bool IsImage => this is ImageFile;
        public bool IsNoImage => !IsImage;
        public bool IsImageWithAttachment => IsImage;

        public ImageFile AsImage => this as ImageFile;
        public ImageFile AsImageWithAttachment => AsImage;

        public bool IsProduct => this is ProductFile;
        public ProductFile AsProduct => this as ProductFile;

        public bool IsCategory => this is CategoryFile;
        public CategoryFile AsCategory => this as CategoryFile;

        public ImageFile ToImageWithAttachment() => new ImageFile(this.AsImage);


        public override string ToString() => Name;


        public static byte[] BytesFromImage(Image image)
        {
            List<byte> result = new List<byte>();

            MemoryStream memory = new MemoryStream();
            image.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] photo = memory.ToArray();
            memory.Close();

            return photo;
        }

        public static Bitmap ImageFromBytes(byte[] photo)
        {

            MemoryStream memory = new MemoryStream(photo);
            Image image = Image.FromStream(memory);
            return new Bitmap(image);
        }

        FolderClass parent;
        public override FolderClass Parent
        {
            get
            {

                try
                {
                    if (parent.NoContains(this))
                        return null;
                    return parent;
                }
                catch
                {
                    return null;
                }
            }
        }

        public int Index
        {
            get
            {
                try
                {
                    return Parent.IndexOf(this);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public string IndexText => $"{Index}"; 

        int leval = 0;
        public int Leval
        {
            get
            {
                int leval = 0;
                try
                {
                    GetRoot(out leval);
                }
                catch
                {
                    leval = 0;
                }
                return leval;
            }
        }

        public FolderClass GetRoot(out int leval)
        {
            leval = 0;
            try
            {
                
                FolderClass folder = parent;
                if (folder is null || folder == null)
                    return null;
                if (parent.NoContains(this))
                {
                    return null;
                }
                folder = parent;
                while (true)
                {
                    try
                    {

                        FolderClass folder1 = folder.Parent;
                        if (folder1 is null || folder1 == null)
                            return folder;
                        folder = folder1;
                        leval++;
                    }
                    catch
                    {
                        break;
                    }

                }

                return folder;
            }
            catch
            {
                return null;
            }
        }

        public override FolderClass Root => GetRoot(out int leval);

        public FileClass GetFile => this;

        public FileClass SetInFolder(FolderClass folder)
        {
            parent = folder;
            TemporaryIndex = Index;
            CreateThisIndexFile();
            return this;
        }

        int temporaryIndex = -1;
        public int TemporaryIndex
        {
            get => temporaryIndex; set => temporaryIndex = value ;
        }

        public string TemporaryIndexText
        {
            get => Convert.ToString(TemporaryIndex); set => TemporaryIndex = Convert.ToInt32(value);
        }

        public void CopyIndex()
        {
            TemporaryIndex = Index;
        }
        public abstract FileClass Copy();


        public string FileName
        {
            get => Name;
            set => Name = value;
        }

        protected virtual void GetProperty(FileClass file)
        {
            SetAbstractFile(file);
            TemporaryIndex = file.TemporaryIndex;
            IndexFile = file.IndexFile;
        }

        public void FromFileClass(FileClass file)
        {
            FileName = file.FileName;
            SetAbstractFile(file);
            
            GetProperty(file);
        }

        public FileClass File
        {
            get => this;
            set => FromFileClass(value);
        }

        public static FileClass Create(FileClass file)
        {
            FileClass result = null;
            if (file.IsImage)
                result = new ImageFile();
            else if (file.IsFolder)
            {
                result = new FolderClass();
            }
            else if(file.IsText)
            {
                result = new TextFile();
            }
            else if (file.IsDataBase)
            {
                result = new DataBaseFile();
            }
            else if(file.IsProductParameter)
            {
                result = file.AsProductParameter.CreateNewFile();
            }

            result.SetFileClass(file);
            return result;
        }

        public void SetFileClass(FileClass file)
        {
            SetAbstractFile(file);
            File = file;
            SetContentFile(file);
            Name = file.Name;
            FileName = file.FileName;
            GetProperty(file);
        }

        public abstract void SetContentFile(FileClass file);

        public bool IsFolder => this is FolderClass;
        public bool IsNoFolder => !IsFolder;
        public FolderClass AsFolder
        {
            get
            {
                if (IsNoFolder)
                    throw new NoFolderInFolderClassException(this);
                return this as FolderClass;
            }
        }

        public override FileClass TagProperty { get => File; set => File = value; }


        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(string namefile, Type type)
        {

            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Open);
            //try
            //{
            //    object obj = json.ReadObject(fileStream);
            //    fileStream.Close();
            //    return obj;
            //}
            //catch (Exception e)
            //{
            //    fileStream.Close();
            //    throw new Exception(e.Message, e);
            //}
            return JsonRead(fileStream, type);

        }

        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(byte[] namefile, Type type)
        {

           // namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            MemoryStream fileStream = new MemoryStream(namefile);
            //try
            //{
            //    object obj = json.ReadObject(fileStream);
            //    fileStream.Close();
            //    return obj;
            //}
            //catch (Exception e)
            //{
            //    fileStream.Close();
            //    throw new Exception(e.Message, e);
            //}
            object result = JsonRead(fileStream, type);
            return result;

        }

        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(Stream namefile, Type type)
        {

            ///namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            Stream fileStream = namefile;
            try
            {
                object obj = json.ReadObject(fileStream);
                fileStream.Close();
                return obj;
            }
            catch (Exception e)
            {
                fileStream.Close();
                throw new Exception(e.Message, e);
            }
            

        }

        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        public static void JsonWrite(object obj, Type type, string namefile)
        {
            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            JsonWrite(obj, type, fileStream);
            //fileStream.Close();
        }

        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        public static void JsonWrite(object obj, Type type, Stream namefile)
        {
            //namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            Stream fileStream = namefile;
            json.WriteObject(fileStream, obj);
            
        }

        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }

        public byte[] GetMemoryJsonByte()
        {
            MemoryStream memory = new MemoryStream();
            JsonWrite(this, this.GetType(), memory);
            byte[] text = memory.ToArray();
            return text;
        }

        public string GetMemoryJson(bool bynary = true)
        {
            MemoryStream memory = new MemoryStream();
            JsonWrite(this, this.GetType(), memory);
            byte[] text = memory.ToArray();
            if (bynary)
            {
                memory.Close();
                return Convert.ToBase64String(text);
            }
            else
            {
                StreamReader reader = new StreamReader(memory);
                string text1 = reader.ReadToEnd();
                reader.Close();
                memory.Close();
                return text1;
            }
        }

        public string GetJson()
        {
            MemoryStream memory = new MemoryStream();
            JsonWrite(this, this.GetType(), memory);
            byte[] text = memory.ToArray();
            UnicodeEncoding encoding = new UnicodeEncoding();

            return encoding.GetString(text);
        }


        public virtual void LoadJson(byte[] fileName)
        {
            File = (FileClass)JsonRead(new MemoryStream(fileName), GetType());
        }

        public virtual void LoadJson(string fileName, bool bytes = false)
        {
            if (!bytes)
            {
                File = (FileClass)JsonRead(fileName, this.GetType());
            }
            else
            {
                LoadJson(Convert.FromBase64String(fileName));
            }
        }

        public virtual Bitmap BitmapView
        {
            get
            {
                return new Bitmap(100, 100);
            }
        }

        public void SetFile(FileClass file)
        {
            Name = file.Name;
            file.CopyIndex();
            TemporaryIndex = file.TemporaryIndex;
            SetAbstractFile(file);
        }

        public ImageFile ImageFileView => new ImageFile(this);


        //bool security = false;

        //[DataMember]
        //public bool Security
        //{
        //    get => security;
        //    set => security = value;
        //}
        //public override FileClass PropertyOfSecurity { get => TagProperty; set => TagProperty = value; }

        //public abstract string TypesFileJson { get; }

        //public string TypesFileJsonWithTxt => TypesFileJson + "|Json (.json)|*.json|Txt (*.txt)|*.txt|STXT (*.stxt)|*.stxt|All Files (*.*)|*.*";


        //public abstract string TypesFileContent { get;}
        //public string TypesFileContentWithTxt => TypesFileContent + "|Txt (*.txt)|*.txt|STXT (*.stxt)|*.stxt|All Files (*.*)|*.*";


        /// <summary>
        /// Полный путь к файлу без корневого каталога
        /// </summary>
        /// <param name="symwol"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string FullPathWithOutRoot(string symwol, out string message)
        {
            message = "Полный путь к файлу без корневого каталога";
            return FullPathWithOutRoot(symwol);
        }

        /// <summary>
        /// Полный путь к файлу без корневого каталога не включая сам файл
        /// </summary>
        /// <param name="symwol"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string StartupPathWithOutRoot(string symwol, out string message)
        {
            message = "Полный путь к файлу без корневого каталога не включая сам файл";
            return StartupPathWithOutRoot(symwol);
        }

        /// <summary>
        /// Полный путь к файлу без корневого каталога
        /// </summary>
        /// <param name="symwol"></param>
        /// <returns></returns>
        public string StartupPathWithOutRoot(string symwol)
        {
            try
            {
                if (symwol != "/" && !symwol.Equals("/"))
                    symwol = "\\";
                string path = "";

                FolderClass folder = Parent;
                for (int i = 1; i < Leval - 1; i++)
                {
                    folder = folder.Parent;
                }

                return symwol + path;
            }
            catch
            {
                return symwol + IndexFileName;
            }
        }


        /// <summary>
        /// Полный путь к файлу включая корневой каталог
        /// </summary>
        /// <param name="symwol"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string FullPathWithRoot(string symwol, out string message)
        {
            message = "Полный путь к файлу включая корневой каталог";
            return FullPathWithRoot(symwol);
        }

        /// <summary>
        /// Полный путь к файлу включая корневой каталог, но не включая сам файл
        /// </summary>
        /// <param name="symwol"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string StartupPathWithRoot(string symwol, out string message)
        {
            message = "Полный путь к файлу включая корневой каталог, но не включая сам файл";
            return StartupPathWithRoot(symwol);
        }

        /// <summary>
        /// Путь к файлу c корневым каталогом
        /// </summary>
        /// <param name="symwol"></param>
        /// <returns></returns>
        public string FullPathWithRoot(string symwol)
        {
            string path = FullPathWithOutRoot(symwol);
            try
            {
                return Root.IndexNameFile + path; 
            }
            catch (Exception ex)
            {
                return path.Remove(0, 1);
            }
        }

        /// <summary>
        /// Путь к файлу c корневым каталогом не вклюая сам файл
        /// </summary>
        /// <param name="symwol"></param>
        /// <returns></returns>
        public string StartupPathWithRoot(string symwol)
        {
            string path = StartupPathWithOutRoot(symwol);
            try
            {
                return Root.IndexNameFile + path;
            }
            catch (Exception ex)
            {
                return path.Remove(0, 1);
            }
        }

        /// <summary>
        /// Полный путь от диска, но не включая сам файл
        /// </summary>
        /// <param name="symwol"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string StartupPathWithDisk(string symwol, out string message)
        {
            message = "Полный путь от диска, но не включая сам файл";
            return StartupPathWithDisk(symwol);
        }

        /// <summary>
        /// Путь к файлу от диска, не включая сам файл
        /// </summary>
        /// <param name="symwol"></param>
        /// <returns></returns>
        public string StartupPathWithDisk(string symwol)
        {
            
            try
            {
                if (IsDisksPart)
                    throw new Exception();
                string path = "";
                FolderClass folder = Parent;
                while(true)
                {
                    if (folder.IsDisksPart)
                        return folder.AsDisksPart.IndexNamePart + symwol + path;
                    path = folder.IndexFileName + symwol;
                    folder = folder.Parent;

                }
            }
            catch (Exception ex)
            {
                if (IsDisksPart)
                    return AsDisksPart.IndexNamePart+symwol;
                return symwol;
            }
        }

        /// <summary>
        /// Полный путь к файлу без корневого каталога не включая сам файлы
        /// </summary>
        /// <param name="symwol"></param>
        /// <returns></returns>
        public string FullPathWithOutRoot(string symwol)
        {
            return StartupPathWithOutRoot(symwol) + IndexFileName;
        }

        /// <summary>
        /// Раздл диска в который записан данный файл
        /// </summary>
        public virtual DiskPartClass DiskPart
        {
            get
            {
                try
                {
                    FolderClass folder = Parent;
                    while (true)
                    {
                        if (folder.IsDisksPart)
                            return folder.AsDisksPart;
                        folder = folder.Parent;
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Диск не найден");
                }
            }
        }

        /// <summary>
        /// Диск на котором записан файл
        /// </summary>
        public virtual DiskClass Disk
        {
            get => DiskPart.Disk;
        }

        /// <summary>
        /// Набор дисков, в котором находится данный диск
        /// </summary>
        public virtual DisksFew DisksFew => Disk.DisksFew;

        public Bitmap ImageView
        {
            get
            {
                try
                {
                    return new Bitmap(BitmapView);
                }
                catch
                {
                    return new Bitmap(100, 100);
                }
            }

        }


        public bool IsLink => this is LinkFile;
        public LinkFile AsLink => this as LinkFile;

        public bool IsNote=> this is NoteFile;
        public NoteFile AsNote => this as NoteFile;

        public bool IsIndexLink => this is IndexLinkFile;
        public IndexLinkFile AsIndexLink => this as IndexLinkFile;

        public IndexLinkFile CreateIndexLink() => IndexLinkFile.CraeteLink(this);

        string indexFile = "";

        [DataMember]
        public string IndexFile
        {
            get => indexFile;
            set => indexFile = value;
        }


        public virtual void CreateThisIndexFile()
        {

            try
            {
                Parent.CreateIndexFile(this);
            }
            catch
            {
                if (IndexFile == null || IndexFile is null)
                {
                    SetIndex();
                    CreateThisIndexFile();
                }
                else if (IndexFile.Length < 1)
                {
                    SetIndex();
                    CreateThisIndexFile();
                }
            }

        }

        void SetIndex()
        {
            string result = "";
            for (int i = 0; i < 20; i++)
            {
                result += rand.Next(10) % 10;
            }
            IndexFile = result;
        }

        Random rand = new Random();

        /// <summary>
        /// Тип файла
        /// </summary>
        public abstract string FileType { get; }
    }

    
    
}
