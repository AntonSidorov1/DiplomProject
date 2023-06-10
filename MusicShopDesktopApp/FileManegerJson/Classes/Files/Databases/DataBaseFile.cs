using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    [DataContract]
    public class DataBaseFile : NameFile
    {
        public DataBaseFile()
        {
        }

        public DataBaseFile(string name, bool file = true) : base(name, file)
        {
        }

        public DataBaseFile(string name, string fileName) : base(name, fileName)
        {
        }

        public override string TypesFileJson => "File Server Connection File Json (*.fsvpj)|*.fsvpj|Sidorov TXT (*.stxt)|*.stxt|Anton TXT (*.atxt)|*.atxt|Json File (*.json)|*.json";

        public override string TypesFileContent => "Server Connection File (*.servpodkl)|*.servpodkl|Sidorov TXT (*.stxt)|*.stxt|Anton TXT (*.atxt)|*.atxt|Json File (*.json)|*.json";

        public override string IndexClassName => "DataBaseFile";


        public override FileClass Copy()
        {
            DataBaseFile image = this;
            DataBaseFile file = image;
            DataBaseFile result = new DataBaseFile
            {
                TemporaryIndex = this.TemporaryIndex,
                Name = Name,
                DataBase = this.DataBase.CopyWithFull(),

                CopyFile = image,
                DateCreateText = file.DateCreateText,
                IndexFileName = file.IndexFileName
            };
            result.SetFile(this);
            return result;
        }

        public override Bitmap BitmapView => Properties.Resources.ClientServer;

        ConnectionDataBase dataBase = new ConnectionDataBase();

        [DataMember]
        public ConnectionDataBase DataBase
        {
            get => dataBase;
            set => dataBase = value;
        }

        public override string FileType => "Строка подключения к базе данных";

        public override void FromFile(AbstractFileClass file)
        {
            base.FromFile(file);
            if (file is FileClass)
            {
                FileClass fileClass = file as FileClass;
                if (fileClass.IsDataBase)
                {
                    DataBase = fileClass.AsDataBase.DataBase.CopyWithFull();
                }
            }
        }

        protected override void GetProperty(FileClass file)
        {
            base.GetProperty(file);
            DataBase = file.AsDataBase.DataBase.CopyWithFull();
        }


        public static DataBaseFile Load(string fileName)
        {

            try
            {
                DataBaseFile dataBase = ((DataBaseFile)JsonRead(fileName, typeof(DataBaseFile))).AsDataBase;
                if (dataBase.DataBase == null || dataBase.DataBase is null)
                    throw new Exception();
                return dataBase;
            }
            catch
            {
                DataBaseFile dataBase = new DataBaseFile(fileName, false)
                {
                    DataBase = ConnectionDataBase.Load(fileName)
                };
                return dataBase;
            }
        }

        public override void SetContentFile(FileClass file)
        {
            
        }
    }
}
