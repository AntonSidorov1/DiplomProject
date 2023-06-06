using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// ФИО
    /// </summary>
    public class FIO : Initials
    {
        
        public FIO()
        {

        }

        public FIO(string fio) : this()
        {
            Initials = fio;
        }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Initials
        {
            get => String.Join(" ", FamilyName, FirstName, SurName).Trim();
            set
            {
                string[] fio = value.Split(' ');

                FamilyName = "";
                FirstName = "";
                SurName = "";

                try
                {
                    FamilyName = fio[0];
                }
                catch
                {
                    FamilyName = "";
                    return;
                }

                try
                {
                    FirstName = fio[1];
                }
                catch
                {
                    FirstName = "";
                    FamilyName = "";
                    return;
                }

                try
                {
                    SurName = fio[2];
                }
                catch
                {
                    SurName = "";
                }

            }
        }

        public override string ToString()
        {
            return Initials;
        }
    }
}
