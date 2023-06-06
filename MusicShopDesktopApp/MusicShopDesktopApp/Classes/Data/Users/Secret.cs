using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    [DataContract]
    public class Secret
    {
        public Secret()
        {

        }

        public Secret(string password)
        {
            Password = password;
        }

        string password = "";

        [DataMember]
        public string Password
        {
            get => password;
            set => password = value;
        }


        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            ConnectionDataBase.JsonWrite(this, this.GetType(), fileName);
        }


        public static Secret Load(string fileName)
        {


            return (Secret)ConnectionDataBase.JsonRead(fileName, typeof(Secret));
        }

        public Secret Copy() => new Secret(Password);

    }
}
