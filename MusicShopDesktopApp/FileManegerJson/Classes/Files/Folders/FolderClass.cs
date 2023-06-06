using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Drawing;

namespace FileManegerJson
{
    [DataContract]
    public class FolderClass : FileClass, IFileList<FileClass, FolderClass>
    {
        public new const string DefaultName = "folder";
        public FolderClass() : base()
        {
            FileName = DefaultName;
            fileClasses = new List<FileClass>();
        }

        public FolderClass(string name):this()
        {
            FileName = name;
        }
        

        public FolderClass(IEnumerable<FileClass> files, string name = DefaultName) :this(name)
        {
            AddRange(files);
            
        }

        List<FileClass> fileClasses = new List<FileClass>();

        public FileClass GetFile1(int index)
        {
            return fileClasses[index];
        }

        public void SetFile(int index, FileClass file)
        {
            fileClasses[index] = file;
            file.SetInFolder(this);
        }

        public FileClass this[int index] { get => GetFile1(index); set
            {
                SetFile(index, value);
                ChangeIndexName(index);
            }
        }

        public int Count => fileClasses.Count;

        public bool IsReadOnly => false;


        public override string Text1
        {
            get => text;
            set
            {
                text = value;
                string[] line = text.Split('/', '\\');
                text = line[line.Length - 1];
            }
        }

        [DataMember]
        public string Text { get => Name; set => Name = value; }

        public void Add(FileClass item)
        {
            try
            {
                fileClasses.Add(item);
            }
            catch
            {
                fileClasses = new List<FileClass>();
                fileClasses.Add(item);
            }
            
            item.SetInFolder(this);
            ChangeIndexName(item);
        }
        public void Insert(FileClass item) => Add(item);

        public ImageFile Add(Bitmap item)
        {
            Add(new ImageFile(item) as FileClass);
            ImageFile imageFile = this[Count - 1].AsImage;
            imageFile.Name = $"image{imageFile.Index}";
            return imageFile;
        }

        public ImageFile Add(Bitmap item, string name)
        {
            ImageFile image = Add(item);
            image.FileName = name;
            return image;
        }

        public ImageFile Add(int index, Bitmap item, string name)
        {
            ImageFile image = Add(index, item);
            image.FileName = name;
            return image;
        }

        public ImageFile Insert(Bitmap item) => Add(item);

        public ImageFile Insert(Bitmap item, string name) => Add(item, name);

        public ImageFile Insert(int index, Bitmap item, string name) => Add(index, item, name);

        public ImageFile Add(int index, Bitmap item)
        {
            Add(index, new ImageFile(item) as FileClass);
            ImageFile imageFile = this[index].AsImage;
            imageFile.Name = $"image{Index}";
            return imageFile;
        }
        public ImageFile Insert(int index, Bitmap item) => Add(index, item);

        public void AddRange(IEnumerable<FileClass> items)
        {
            List<FileClass> files = new List<FileClass>(items);
            for(int i = 0; i < files.Count; i++)
            {
                Add(files[i]);
            }
        }
        public void Add(IEnumerable<FileClass> items) => AddRange(items);
        public void InsertRange(IEnumerable<FileClass> items) => Add(items);
        public void Insert(IEnumerable<FileClass> items) => InsertRange(items);

        public void Clear() => fileClasses.Clear();

        public bool Contains(FileClass item) => fileClasses.Contains(item);
        public bool NoContains(FileClass item) => !Contains(item);

        public void CopyTo(FileClass[] array, int arrayIndex) => fileClasses.CopyTo(array, arrayIndex);

        public IEnumerator<FileClass> GetEnumerator() => fileClasses.GetEnumerator();

        public int IndexOf(FileClass item) => fileClasses.IndexOf(item);

        public void Insert(int index, FileClass item)
        {
            fileClasses.Insert(index, item);

            item.SetInFolder(this);
        }
        public void Add(int index, FileClass item) => Insert(index, item);

        public void AddRange(int index, IEnumerable<FileClass> items)
        {
            List<FileClass> files = new List<FileClass>(items);
            for (int i = 0; i < files.Count; i++)
            {
                Add(index, files[i].SetInFolder(this));
                index++;
            }
        }
        public void Add(int index, IEnumerable<FileClass> items) => AddRange(index, items);
        public void InsertRange(int index, IEnumerable<FileClass> items) => Add(index, items);
        public void Insert(int index, IEnumerable<FileClass> items) => InsertRange(index, items);

        public bool Remove(FileClass item) => fileClasses.Remove(item);

        public void RemoveAt(int index)
        {
            try
            {
                fileClasses.RemoveAt(index);
            }
            catch
            {
                fileClasses = new List<FileClass>();

            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public FileClass Find(Predicate<FileClass> predicate) => fileClasses.Find(predicate);
        public int FindIndex(Predicate<FileClass> predicate)
        {
            try
            {
                return fileClasses.FindIndex(predicate);
            }
            catch
            {
                fileClasses = new List<FileClass>();
                return fileClasses.FindIndex(predicate);
            }
        }
        public List<FileClass> FindAll(Predicate<FileClass> predicate) => fileClasses.FindAll(predicate);

        public void Remove (Predicate<FileClass> predicate)
        {
            int index;
            do
            {
                index = FindIndex(predicate);
                if (index > -1)
                    RemoveAt(index);
            }
            while (index > -1);
        }

        public void ClearImages() => Remove(f => f.IsImage);
        public void ClearFolders() => Remove(f => f.IsFolder);
        public void ClearTexts() => Remove(f => f.IsText);
        public void ClearDataBase() => Remove(f => f.IsDataBase);
        public void ClearNotes() => Remove(f => f.IsNote);
        public void ClearOrganizaions() => Remove(f => f.IsOrganizaion);
        public void ClearSities() => Remove(f => f.IsSity);


        public ImageFilesList ImageList
        {
            get
            {
                List<FileClass> files = FindAll(f => f.IsImage);
                return new ImageFilesList(files, false);
            }
            set
            {
                try
                {
                    ClearImages();
                }
                catch
                {

                }
                Add(value);
            }
        }

        public ImageFile[] ImageArray
        {
            get => ImageList.ImageFilesArray;
            set
            {
                ImageList = new ImageFilesList(value);
            }
            
        }

        [DataMember]
        public ImageFileJson[] ImageArray1
        {
            get => ImageList.FileJsons;
            set
            {
                ImageList = new ImageFilesList(value);
            }

        }

        public FolderClass OpenFolder(string indexName)
        {
            FileClass file = this[indexName];
            if (file.IsNoFolder)
                throw new NoFolderInFolderClassException(this, indexName);
            return file.AsFolder;
        }

        public FileClass GetFileFromPath(string path)
        {
            FileClass file = this;

            FolderClass folder = this;

            string[] files = path.Split('/', '\\');
            string file1 = files[0];
            bool thisFolder = false;
            if (file1 == "" || file1.Equals(""))
                file = Root;
            else if (file1 == "." || file1.Equals("."))
                file = this;
            else
            {
                file = this[file1];
                thisFolder = true;
            }
                int count = files.Length;
            if (count == 1)
            {
                return file;
            }
            else
            {
                if (thisFolder)
                {
                    folder = OpenFolder(file1);
                }
                
                file1 = files[1];
                if (file1 == "" || file1.Equals(""))
                    return folder;
                file = folder[file1];
            }
            for(int i = 2; i < count; i++)
            {
                folder = folder.OpenFolder(file1);
                file1 = files[i];
                if (file1 == "" || file1.Equals(""))
                    return folder;
                file = folder[file1];
            }

            return file;
        }

        public override ref string RefName => ref text;

        public ImageFile GetImage(int index) => this[index].AsImage;

        public override FileClass Copy()
        {
            return new FolderClass(this.CopyArray());
        }



        public List<FileClass> ToList()
        {
            return new List<FileClass>(fileClasses);
        }

        public List<FileClass> FilesList
        {
            get => ToList();
            set
            {
                Clear();
                AddRange(value);
            }
        }

        public bool Contains (Predicate<FileClass> predicate)
        {
            return FindIndex(predicate) != -1;
        }

        public bool NoContains(string indexFileName)
        {
            return !Contains(indexFileName);
        }

        public bool Contains (string indexFileName)
        {
            return Contains(p => p.IndexFileName == indexFileName);
        }

        public bool NoContainsIndexName(FileClass file)
        {
            return NoContains(file.IndexFileName);
        }

        public bool ContainsIndexName(FileClass file)
        {
            return Contains(file.IndexFileName);
        }

        public int IndexOf(string indexFileName)
        {
            return FindIndex(p => p.IndexFileName == indexFileName);
        }

        public int LastIndexOf(string indexFileName)
        {
            return FindLastIndex(p => p.IndexFileName == indexFileName);
        }

        public int FindLastIndex(Predicate<FileClass> predicate)
        {
            return fileClasses.FindLastIndex(predicate);
        }

        public int LastIndexOf(FileClass file)
        {
            return fileClasses.LastIndexOf(file);
        }

        public FileClass First() => fileClasses.First();
        public FileClass FirstOrDefault() => fileClasses.FirstOrDefault();

        public FileClass Last() => fileClasses.Last();
        public FileClass LastOrDefault() => fileClasses.LastOrDefault();

        public FileClass GetFileClass(string indexFileName)
        {
            if (NoContains(indexFileName))
                throw new FileEpsendInFolderClassException(this, indexFileName);
            int index = IndexOf(indexFileName);
            return this[index];
        }

        public void SetFileClass(string indexFileName, FileClass fileClass)
        {
            if(NoContains(indexFileName))
            {
                Add(fileClass);
                fileClass.IndexFileName = indexFileName;
                return;
            }
            int index = IndexOf(indexFileName);
            this[index] = fileClass;
            
        }

        public FileClass this[string indexFileName]
        {
            get => GetFileClass(indexFileName);
            set => SetFileClass(indexFileName, value);
        }

        public override void ChangeIndexName()
        {
            base.ChangeIndexName();
        }

        public List<FileClass> FindAll(string indexFileName) => FindAll(p => p.IndexFileName == indexFileName);

        public int CountIndexName(string indexFileName) => FindAll(indexFileName).Count;

        public bool IndexNameUnique(string indexFileName) => CountIndexName(indexFileName) < 2;


        public void ChangeIndexName(int index)
        {
            FileClass file = this[index];
            file.ChangeIndexName();

                string indexFileName = file.IndexFileName;
                if(IndexNameUnique(indexFileName))
            {
                return;
            }
                

                file.IndexFileName += "_Копия" + index;
                UInt32 index1 = 0;
                indexFileName = file.IndexFileName;
            string indexFileName1 = indexFileName;

            while (!IndexNameUnique(indexFileName1))
            {
                index1++;
                indexFileName1 = indexFileName + "_" + index1;
            }
            file.IndexFileName = indexFileName1;

        }

        public void ChangeIndexName(FileClass file)
        {
            ChangeIndexName(IndexOf(file));
        }

        public void ChangeIndexNameAllFiles()
        {
            ChangeIndexName();
            for(int i = 0; i < Count; i++)
            {
                ChangeIndexName(i);
            }
        }

        public string GetIndexName(int index)
        {
            return (string)this[index];
        }





        public bool NoContains(Predicate<FileClass> predicate)
        {
            return !Contains(predicate);
        }

        public List<FolderClass> FolderList
        {
            get
            {
                List<FolderClass> folders = new List<FolderClass>();
                List<FileClass> folders1 = FindAll(f => f.IsFolder);
                for(int i = 0; i < folders1.Count; i++)
                {
                    if (folders1[i].IsFolder)
                        folders.Add(folders1[i].AsFolder);
                }
                return folders;
            }
            set
            {
                try
                {
                    ClearFolders();
                    Add(value);
                }
                catch
                {

                }
            }
        }

        public List<TextFile> TextList
        {
            get
            {
                List<TextFile> folders = new List<TextFile>();
                List<FileClass> folders1 = FindAll(f => f.IsText);
                for (int i = 0; i < folders1.Count; i++)
                {
                    if (folders1[i].IsText)
                        folders.Add(folders1[i].AsText);
                }
                return folders;
            }
            set
            {
                try
                {
                    ClearTexts();
                    Add(value);
                }
                catch
                {

                }
            }
        }

        [DataMember]
        public NoteFile[] NotesArray
        {
            get => NoteList.ToArray();
            set => NoteList = new List<NoteFile>(value);
        }

        public List<NoteFile> NoteList
        {
            get
            {
                List<NoteFile> folders = new List<NoteFile>();
                List<FileClass> folders1 = FindAll(f => f.IsNote);
                for (int i = 0; i < folders1.Count; i++)
                {
                    if (folders1[i].IsNote)
                        folders.Add(folders1[i].AsNote);
                }
                return folders;
            }
            set
            {
                try
                {
                    ClearNotes();
                    Add(value);
                }
                catch
                {

                }
            }
        }

        [DataMember]
        public OrganizaionFile[] OrganizaionsArray
        {
            get => OrganizaionList.ToArray();
            set => OrganizaionList = new List<OrganizaionFile>(value);
        }

        public List<OrganizaionFile> OrganizaionList
        {
            get
            {
                List<OrganizaionFile> folders = new List<OrganizaionFile>();
                List<FileClass> folders1 = FindAll(f => f.IsOrganizaion);
                for (int i = 0; i < folders1.Count; i++)
                {
                    if (folders1[i].IsOrganizaion)
                        folders.Add(folders1[i].AsOrganizaion);
                }
                return folders;
            }
            set
            {
                try
                {
                    ClearOrganizaions();
                    Add(value);
                }
                catch
                {

                }
            }
        }

        [DataMember]
        public SityFile[] SitiesArray
        {
            get => SityList.ToArray();
            set => SityList = new List<SityFile>(value);
        }

        public List<SityFile> SityList
        {
            get
            {
                List<SityFile> folders = new List<SityFile>();
                List<FileClass> folders1 = FindAll(f => f.IsSity);
                for (int i = 0; i < folders1.Count; i++)
                {
                    if (folders1[i].IsSity)
                        folders.Add(folders1[i].AsSity);
                }
                return folders;
            }
            set
            {
                try
                {
                    ClearSities();
                    Add(value);
                }
                catch
                {

                }
            }
        }

        public List<DataBaseFile> DataBasesList
        {
            get
            {
                List<DataBaseFile> folders = new List<DataBaseFile>();
                List<FileClass> folders1 = FindAll(f => f.IsDataBase);
                for (int i = 0; i < folders1.Count; i++)
                {
                    if (folders1[i].IsDataBase)
                        folders.Add(folders1[i].AsDataBase);
                }
                return folders;
            }
            set
            {
                try
                {
                    ClearDataBase();
                    Add(value);
                }
                catch
                {

                }
            }
        }

        [DataMember]
        public FolderClass[] FoldersArray
        {
            get => FolderList.ToArray();
            set => FolderList = new List<FolderClass>(value);
        }

        [DataMember]
        public TextFile[] TextsArray
        {
            get => TextList.ToArray();
            set => TextList = new List<TextFile>(value);
        }

        [DataMember]
        public DataBaseFile[] DataBasesArray
        {
            get => DataBasesList.ToArray();
            set => DataBasesList = new List<DataBaseFile>(value);
        }

        public FileClass[] ToArray() => FilesList.ToArray();

        protected override void GetProperty(FileClass file)
        {
            base.GetProperty(file);
            FilesArray = file.AsFolder.CopyArray();
        }

        public FileClass[] FilesArray
        {
            get => ToArray();
            set
            {
                FilesList = new List<FileClass>(value);
            }
        }

        public override string TypesFileJson => "Json Catalog Files (*.jcat)|*.jcat|Json Disk Files (*.disk)|*.disk|Json Catalog disk Files (*.cdisk)|*.cdisk|Json Folder disk Files (*.fdisk)|*.fdisk|Json Json disk Files (*.jdisk)|*.jdisk|All Json disk Files (*.jcat;*.disk;*.cdisk;*.fdisk;*.jdisk)|*.jcat;*.disk;*.cdisk;*.fdisk;*.jdisk";

        public override string TypesFileContent => TypesFileJson;

        public override string IndexClassName => "FolderClass";


        public FileClass[] CopyArray()
        {
            
                FileClass[] files = new FileClass[Count];
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = Create(FilesArray[i]);
                }
                return files;
        }


        public override void LoadJson(string fileName, bool bytes = false)
        {
            if (!bytes)
            {
                File = (FolderClass)JsonRead(fileName, this.GetType());
            }
            else
            {
                LoadJson(Convert.FromBase64String(fileName));
            }
        }

        public override void SetContentFile(FileClass file)
        {
            
        }

        public List<FileClass> ListNoImage => FindAll(f => !f.IsImage);
    }
}
