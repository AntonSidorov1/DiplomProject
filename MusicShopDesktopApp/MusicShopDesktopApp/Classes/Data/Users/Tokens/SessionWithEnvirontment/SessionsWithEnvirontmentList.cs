using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Список сессий с окружением
    /// </summary>
    public class SessionsWithEnvirontmentList : List<SessionWithEnvirontment>
    {
        public SessionsWithEnvirontmentList()
        {
        }

        public SessionsWithEnvirontmentList(IEnumerable<SessionWithEnvirontment> collection) : base(collection)
        {
        }

        public SessionsWithEnvirontmentList(int capacity) : base(capacity)
        {
        }

        public static SessionsWithEnvirontmentList GetList() => new SessionsWithEnvirontmentList();

        public SessionsWithEnvirontmentList GetThis() => this;

        public static SessionsWithEnvirontmentList GetListFromDB(Account login, Session session)
        {
            SessionsWithEnvirontmentList sessions = GetList();
            sessions.GetFromDB(login, session);
            return sessions;
        }

        
        public void GetFromDB(Account login, Session thisToken, int count = 20)
        {
            try
            {
                EnvirontmentTokenController.UpdateSessions();
            }
            catch
            {

            }
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select [LoginToken], " +
                    "[DateOpen]," +
                    "[LoginActive]" +
                    ",[LoginSuccessfully]," +
                    "[UserLogin]  " +
                    "From [LoginHistoryView] ";
                command.Parameters.Clear();

                SqlDataReader reader = command.ExecuteReaderAsync().Result;
                Clear();
                List<SessionActive> sessionEdit = new List<SessionActive>();
                try
                {
                    while (reader.ReadAsync().Result)
                    {
                        SessionEdit session = new SessionEdit();
                        session.Token = reader.GetString(0);
                        session.Date = reader.GetDateTime(1);
                        SessionActive token = session.CopyWithActive();
                        token.Active = reader.GetBoolean(2);
                        token.Successfully = reader.GetBoolean(3);
                        token.Login = reader.GetString(4);
                        token.SetThisUseEquals(thisToken);
                        sessionEdit.Add(token);
                    }

                    sessionEdit = sessionEdit.FindAll(s => s.EqualsLogin(login));

                    reader.Close();
                    connection.Close();

                    for(int i = 0; i < sessionEdit.Count; i++)
                    {
                        try
                        {
                            Add(sessionEdit[i].CopyWithEnvirontment());
                        }
                        catch(Exception e)
                        {

                        }
                    }

                }
                catch (Exception e)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {

                    }
                    throw e;
                }

            }
            catch (Exception e)
            {
                try
                {
                    connection.Close();
                }
                catch
                {

                }
                if (count > 20)
                {
                    Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                    GetFromDB(login, thisToken, count - 1);
                    return;
                }
                throw e;
            }
        }
    }
}
