using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FileManegerJson
{
    [DataContract]
    public class ConnectionStringDataBase
    {

        string server = "", dataBase = "", userID = "", password = "";
        bool integratedSecurity = true, persistSecurityInfo = false, localServer = true;

        [DataMember]
        public string UserID
        {
            get => userID;
            set => userID = value;
        }

        [DataMember]
        public string Password
        {
            get => password;
            set => password = value;
        }

        [DataMember]
        public bool IntegratedSecurity
        {
            get => integratedSecurity;
            set => integratedSecurity = value;
        }

        [DataMember]
        public bool PersistSecurityInfo
        {
            get => persistSecurityInfo;
            set => persistSecurityInfo = value;
        }

        [DataMember]
        public string DataSource
        {
            get => server;
            set => server = value;
        }

        [DataMember]
        public string InitialCatalog
        {
            get => dataBase;
            set => dataBase = value;
        }

        [DataMember]
        public string Server
        {
            get => DataSource;
            set => DataSource = value;
        }

        [DataMember]
        public string DataBase
        {
            get => InitialCatalog;
            set => InitialCatalog = value;
        }

        public ConnectionStringDataBase Copy()
        {
            ConnectionStringDataBase result = new ConnectionStringDataBase();
            result.DataSource = DataSource;
            result.InitialCatalog = InitialCatalog;
            result.IntegratedSecurity = IntegratedSecurity;
            result.PersistSecurityInfo = PersistSecurityInfo;
            result.UserID = UserID;
            result.Password = Password;
            return result;
        }

        public ConnectionDataBase CopyWithFull()
        {
            ConnectionDataBase result = new ConnectionDataBase();
            result.DataSource = DataSource;
            result.InitialCatalog = InitialCatalog;
            result.IntegratedSecurity = IntegratedSecurity;
            result.PersistSecurityInfo = PersistSecurityInfo;
            result.UserID = UserID;
            result.Password = Password;
            return result;
        }

    }
}
