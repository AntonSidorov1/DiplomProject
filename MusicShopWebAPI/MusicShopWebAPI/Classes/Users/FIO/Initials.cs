using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Инициалы
    /// </summary>
    public class Initials
    {
        string familyName = "";

        /// <summary>
        /// Фамилия
        /// </summary>
        public string FamilyName
        {
            get => familyName;
            set => familyName = value;
        }

        string firstName = "";

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        string surName = "";

        /// <summary>
        /// Отчество
        /// </summary>
        public string SurName
        {
            get => surName;
            set => surName = value;
        }

        public InitialsSession GetInitialsSession(string token)
        {
            return new InitialsSession
            {
                FamilyName = this.FamilyName,
                FirstName = this.FirstName,
                SurName = this.SurName,
                Token = token
            };
        }

    }
}
