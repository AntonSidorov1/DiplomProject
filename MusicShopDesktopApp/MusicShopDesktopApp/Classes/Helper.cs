using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public static class Helper
    {
        static Environtment environtment = new Environtment();

        public static Environtment Environtment
        {
            get => environtment;
            set => environtment = value;
        }

        static EnvirontmentSession environtmentSession = new EnvirontmentSession();

        public static EnvirontmentSession EnvirontmentSession
        {
            get => environtmentSession;
            set => environtmentSession = value;
        }

        public static void OpenEnvirontmentSession()
        {
            EnvirontmentTokenController environtment = new EnvirontmentTokenController();
            EnvirontmentSession = environtment.Open(Environtment);
        }

        static Session session = new Session();

        public static Session Session
        {
            get => session;
            set => session = value;
        }

        public static void OpenSessionForGoest()
        {
            try
            {
                Session = SessionsController.GetController().LoginGoest(EnvirontmentSession);
            }
            catch(Exception e)
            {
                DataBaseConnectionEdit connection = new DataBaseConnectionEdit();
                if (!connection.Check())
                    throw e;
                OpenEnvirontmentSession();
                OpenSessionForGoest();
            }
        }

        /// <summary>
        /// Получить токен сессии
        /// </summary>
        /// <returns></returns>
        public static Session GetSession()
        {
            if(SessionsController.GetController().CheckActive(Session))
            {
                return Session;
            }
            else
            {
                OpenSessionForGoest();
                return GetSession();
            }
        }


        public static TelefonSession GetTelefonSession(string telefon)
        {
            return new TelefonSession(GetSession().Token)
            {
                Telefon = telefon
            };
        }

        public static EmailSession GetEmailSession(string telefon)
        {
            return new EmailSession(GetSession().Token)
            {
                Email = telefon
            };
        }

        public static bool AddTelefon(string telefon)
        {
            return TelefonsController.GetController().AddTelefon(GetTelefonSession(telefon));
        }

        public static bool DeleteTelefon(int telefon)
        {
            return TelefonsController.GetController().DeleteTelefon(GetSession(), telefon);
        }

        public static bool AddEmail(string telefon)
        {
            return EmailsController.GetController().AddEmail(GetEmailSession(telefon));
        }

        public static bool DeleteEmail(int telefon)
        {
            return EmailsController.GetController().DeleteEmail(GetSession(), telefon);
        }


        public static object[] GetTelefonsItems()
        {
            TelefonsList telefons = TelefonsController.GetController().Get(Session);
            List<object> items = new List<object>();
            items.AddRange(telefons);
            return items.ToArray();
        }

        public static object[] GetEmailsItems()
        {
            EmailsList telefons = EmailsController.GetController().Get(Session);
            List<object> items = new List<object>();
            items.AddRange(telefons);
            return items.ToArray();
        }


        public static AccountWithRoles GetAccount()
        {
            try
            {
                return new AccountsController().GetAccount(Session);
            }
            catch (Exception e)
            {
                try
                {
                    OpenSessionForGoest();
                    return GetAccount();
                }
                catch
                {
                    return new AccountWithRoles()
                    {
                        Roles = new RolesList(
                            new Role[]
                            {
                                new Role
                                {
                                    ID = 0,
                                    RoleEng = "Goest",
                                    RoleRus = "Гость"
                                }
                            })
                    };
                }
            }
        }

        /// <summary>
        /// Пользователь - клиент
        /// </summary>
        /// <returns></returns>
        public static bool IsClient()
        {
            try
            {
                return GetAccount().Roles.Any(r => r.ID == 1);
            }
            catch
            {
                return false;
            }
        }

        static Session sessionConnection = new Session();

        public static Session SessionConnection
        {
            get => sessionConnection;
            set => sessionConnection = value;
        }

        public static void GetSessionConnection(string password)
        {
            LoginForEditConnection connection = new LoginForEditConnection();
            SessionConnection = connection.Open(new Secret(password));
        }

        public static bool GetSessionConnection()
        {
            if (!Helper.GetAccount().IsAdmin())
                return false;
            LoginForEditConnection connection = new LoginForEditConnection();
            try
            {
                SessionConnection = connection.OpenByAdmin(Helper.GetSession());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ConnectionDataBase GetConnection()
        {
            DataBaseConnectionEdit dataBase = new DataBaseConnectionEdit();
            return dataBase.GetParts(SessionConnection).CopyWithFull();
        }

        public static void SetConnection(string connectionDataBase)
            => SetConnection(new ConnectionDataBase(connectionDataBase));

        public static void SetConnection(ConnectionDataBase connectionDataBase)
        {
            DataBaseConnectionEdit dataBase = new DataBaseConnectionEdit();
            if (!dataBase.Change(connectionDataBase, SessionConnection))
                throw new ArgumentNullException("Невозможно отредактировать строку подключения");
        }

        public static void GetEnvirontmentByUser()
        {
            try
            {
                EnvirontmentTokenController environtment = new EnvirontmentTokenController();
                EnvirontmentSession = environtment.GetByGoest(Session);
            }
            catch
            {
                EnvirontmentSession = SessionsController.GetController().GetEnvirontmentSession(Session);
            }
        }

        public static bool UserIsGoest()
        {
            try
            {
                return !SessionsController.GetController().CheckActive(Session) || UserRolesController.UserIsGoest(Session);
            }
            catch
            {
                return true;
            }
        }

        static ProductsController productsController = new ProductsController();

        public static ProductsController ProductsController
        {
            get => productsController;
            set => productsController = value;
        }

        static ProductsList products = new ProductsList();

        public static ProductsList Products
        {
            get => products;
            set => products = value;
        }

        public static int ID => GetAccount().ID;


        public static string GetAddressEditType(AddressType type)
        {
            if (type == AddressType.Telefon)
                return "Редактирование телефонов";
            else
                return "Редактирование Email-адресов";
        }

        public static string GetAddressType(AddressType type, bool only = true)
        {
            if (type == AddressType.Telefon)
                return "Телефон" + (only? "":"ы");
            else
                return "Email-Адрес" + (only ? "" : "а");
        }

        public static class TraidHelper
        {
            public static void SetOrganization()
            {

                if (TradingPoint.ID > 0)
                {
                    try
                    {
                        OrganizationsList organizations = OrganizationsList.GetListFromDB();
                        Organization = organizations.GetByID(TradingPoint.OrganizationID);
                    }
                    catch
                    {

                    }
                }
            }

            public static void SetStock()
            {

                if (TradingPoint.ID > 0)
                {
                    try
                    {
                        StocksList organizations = StocksList.GetListFromDB();
                        Stock = organizations.GetByID(TradingPoint.StockID);
                    }
                    catch
                    {

                    }
                }
            }

            public static void SetSity()
            {

                if (Stock.ID > 0)
                {
                    try
                    {
                        SitiesList organizations = SitiesList.GetListFromDB();
                        Sity = organizations.GetByID(Stock.SityID);
                    }
                    catch
                    {

                    }
                }
            }

            public static void SetData()
            {
                SetOrganization();
                SetStock();
                SetSity();
            }


            public static Sity Sity = new Sity();
            public static Stock Stock = new Stock();
            public static Organization Organization = new Organization();
            public static TradingPoint TradingPoint = new TradingPoint();
            public static PounktType PounktType = PounktType.All;
            public static bool Checked = false;

            public static string GetSity()
            {
                if (!Checked)
                    return "";
                if(Sity.ID == 0)
                {
                    return "";
                }
                return $"Город - {Sity.Name}\n\n";
            }

            public static string GetStock()
            {
                if (!Checked)
                    return "";
                if (Stock.ID == 0)
                {
                    return "";
                }
                return $"Склад: \n {Stock.RegistrateData}\n\n";
            }

            public static string GetTraidingPoint()
            {
                if (!Checked)
                    return "";
                if (TradingPoint.ID == 0)
                {
                    return "";
                }
                if(PounktType == PounktType.All)
                {
                    return $"Торговый пункт: \n {TradingPoint.RegistrateData}\n\n";
                }
                string point = (PounktType == PounktType.Shop ? "Магазин" : "Пункт выдачи");
                return $"{point}: \n {TradingPoint.RegistrateData}\n\n";
            }


            public static string GetOrganization()
            {
                if (!Checked)
                    return "";
                if (Organization.ID == 0)
                {
                    return "";
                }
                return $"Организация - {Organization.Name}\n\n";
            }


            public static string GetTraidingPointData()
            {
                return GetOrganization() + "" +
                    GetSity() + "" +
                    GetStock() + "" +
                    GetTraidingPoint() + "";
            }

            public static void Clear()
            {
                Sity = new Sity();
                Organization = new Organization();
                Stock = new Stock();
                TradingPoint = new TradingPoint();
                PounktType = PounktType.All;
                Checked = false;
            }

            public static int ShopID() => TradingPoint.ID;

            public static int StockID()
            {
                if (Stock.ID != 0)
                    return Stock.ID;
                if (TradingPoint.StockID != 0)
                    return TradingPoint.StockID;
                return 0;
            }
        }

        /// <summary>
        /// Корзина
        /// </summary>
        public static ProductsInShoppingCartList ShoppingCarts = new ProductsInShoppingCartList();


        static bool setClient = true;

        public static bool SetClient
        {
            get
            {
                AccountWithRoles account = Helper.GetAccount();
                if (account.IsOnlyRole())
                    return IsClient();
                else if (account.IsClient())
                    return setClient;
                else
                    return false;
            }
            set
            {
                setClient = value;
            }
        }


        static bool setOrdersManager = true;

        public static bool SetOrdersManager
        {
            get
            {
                AccountWithRoles account = Helper.GetAccount();
                if (account.IsOnlyRole())
                    return account.IsOrdersManager();
                else if (account.IsOrdersManager())
                    return setOrdersManager;
                else
                    return false;
            }
            set
            {
                setOrdersManager = value;
            }
        }

        static bool setStockManager = true;

        public static bool SetStockManager
        {
            get
            {
                AccountWithRoles account = Helper.GetAccount();
                if (account.IsOnlyRole())
                    return account.IsStockManager();
                else if (account.IsStockManager())
                    return setStockManager;
                else
                    return false;
            }
            set
            {
                setStockManager = value;
            }
        }

        static bool setSalesMan = true;

        public static bool SetSalesMan
        {
            get
            {
                AccountWithRoles account = Helper.GetAccount();
                if (account.IsOnlyRole())
                    return account.IsSalesMan();
                else if (account.IsSalesMan())
                    return setSalesMan;
                else
                    return false;
            }
            set
            {
                setSalesMan = value;
            }
        }

        static bool setAdmin = true;

        public static bool SetAdmin
        {
            get
            {
                AccountWithRoles account = Helper.GetAccount();
                if (account.IsOnlyRole())
                    return account.IsAdmin();
                else if (account.IsAdmin())
                    return setAdmin;
                else
                    return false;
            }
            set
            {
                setAdmin = value;
            }
        }

        static bool setOperator = true;

        public static bool SetOperator
        {
            get
            {
                AccountWithRoles account = Helper.GetAccount();
                if (account.IsOnlyRole())
                    return account.IsOperator();
                else if (account.IsOperator())
                    return setOperator;
                else
                    return false;
            }
            set
            {
                setOperator = value;
            }
        }

        public static bool IsOrderCreater
            => SetClient || SetAdmin || SetOperator || SetOrdersManager || SetSalesMan;
    }

    public enum AddressType
    {
        Telefon,
        Email
    }
}
