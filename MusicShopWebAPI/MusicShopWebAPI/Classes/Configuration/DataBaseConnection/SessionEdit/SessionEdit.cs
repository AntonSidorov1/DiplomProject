using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class SessionEdit : Session
    {

        public Session GetSession() => new Session(Session);

        bool allowEditConnection = false;

        public bool AllowEditConnection
        {
            get => allowEditConnection;
            set => allowEditConnection = value;
        }

        public SessionEdit():this(20)
        {

        }

        public SessionEdit(int countSymwol) : this(new List<SessionEdit>(), countSymwol)
        {

        }

        public SessionEdit(List<SessionEdit> sessions, int countSymwol = 20)
        {
            do
            {
                CreateToken(countSymwol);
            }
            while (sessions.Any(session => session.Session == Session || session.Token == Token));
        }

        private DateTime date;

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public int Minuts => Math.Abs((DateTime.Now.Subtract(Date)).Minutes);

        public string DateText
        {
            get
            {
                string[] parts = Date.ToString("dd/MM/yyyy hh:mm:ss").Split(new char[] { '/', ' ', ':', '.' });
                List<string> symwols = new List<string>();
                for(int i = 0; i < parts.Length; i++)
                {
                    string symvol = parts[i];
                    symvol = GetSymwol(Convert.ToInt32(symvol));
                    symwols.Add(symvol);
                }
                return string.Join("", symwols);
            }
        }

        public string Session => Token + DateText;

        public void CreateToken(int countSymwol = 20)
        {
            date = DateTime.Now;
            List<string> letters = new List<string>();
            Random rand = new Random();
            for(int i = 0; i < countSymwol; i++)
            {
                letters.Add(GetSymwol(rand.Next(0, 36)));
            }
            Token = string.Join("",letters);
        }

        public static string GetSymwol(int digin36)
        {
            digin36 = Math.Abs(digin36);
            switch(digin36)
            {
                case 0: return "0"; break;
                case 1: return "1"; break;
                case 2: return "2"; break;
                case 3: return "3"; break;
                case 4: return "4"; break;
                case 5: return "5"; break;
                case 6: return "6"; break;
                case 7: return "7"; break;
                case 8: return "8"; break;
                case 9: return "9"; break;
                case 10: return "A"; break;
                case 11: return "B"; break;
                case 12: return "C"; break;
                case 13: return "D"; break;
                case 14: return "E"; break;
                case 15: return "F"; break;
                case 16: return "G"; break;
                case 17: return "H"; break;
                case 18: return "I"; break;
                case 19: return "J"; break;
                case 20: return "K"; break;
                case 21: return "L"; break;
                case 22: return "M"; break;
                case 23: return "N"; break;
                case 24: return "O"; break;
                case 25: return "P"; break;
                case 26: return "Q"; break;
                case 27: return "R"; break;
                case 28: return "S"; break;
                case 29: return "T"; break;
                case 30: return "U"; break;
                case 31: return "V"; break;
                case 32: return "W"; break;
                case 33: return "X"; break;
                case 34: return "Y"; break;
                case 35: return "Z"; break;
                default:
                    {
                        int digit = digin36 / 36;
                        int digit1 = digin36 % 36;

                        return GetSymwol(digit) + GetSymwol(digit1);
                    }; break;
            }
        }


        public override JwtSession CopyJWT()
        {
            return GetSession().CopyJWT();
        }

        public override EnvirontmentSession Copy()
        {
            return GetSession().Copy();
        }


        ///// <summary>
        ///// Создаёт копию с окружением
        ///// </summary>
        ///// <param name="environtment"></param>
        ///// <returns></returns>
        //public override SessionWithEnvirontment CopyWithEnvirontment(Environtment environtment)
        //{
        //    return GetSession().CopyWithEnvirontment(environtment);
        //}

        public override SessionActive CopyWithActive()
        {
            SessionActive session = GetSession().CopyWithActive();
            session.DateOpen = Date;
            return session;
        }
    }
}
