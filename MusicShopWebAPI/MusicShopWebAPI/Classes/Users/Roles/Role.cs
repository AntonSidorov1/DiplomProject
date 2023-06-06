using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class Role
    {
        int id = 0;

        public int ID
        {
            get => id;
            set => id = value;
        }

        string roleRus = "";

        public string RoleRus
        {
            get => roleRus;
            set => roleRus = value;
        }

        public bool EqualsRus(string role)
        {
            return StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.None) == StringNormalize.Normalize(role, formatEnd: FormatEnd.None)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.FromEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.None)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.ToEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.None)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.None) == StringNormalize.Normalize(role, formatEnd: FormatEnd.FromEnd)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.FromEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.FromEnd)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.ToEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.FromEnd)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.None) == StringNormalize.Normalize(role, formatEnd: FormatEnd.ToEnd)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.FromEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.ToEnd)
                || StringNormalize.Normalize(RoleRus, formatEnd: FormatEnd.ToEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.ToEnd);
        }

        public bool EqualsEng(string role)
        {
            return StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.None) == StringNormalize.Normalize(role, formatEnd: FormatEnd.None)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.FromEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.None)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.ToEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.None)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.None) == StringNormalize.Normalize(role, formatEnd: FormatEnd.FromEnd)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.FromEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.FromEnd)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.ToEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.FromEnd)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.None) == StringNormalize.Normalize(role, formatEnd: FormatEnd.ToEnd)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.FromEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.ToEnd)
                || StringNormalize.Normalize(RoleEng, formatEnd: FormatEnd.ToEnd) == StringNormalize.Normalize(role, formatEnd: FormatEnd.ToEnd);
        }

        public bool Equals(string role) => EqualsRus(role) || EqualsEng(role);

        string roleEng = "";

        public string RoleEng
        {
            get => roleEng;
            set => roleEng = value;
        }

        public static bool operator ==(Role role, string roleName) => role.Equals(roleName);

        public static bool operator !=(Role role, string roleName) => !role.Equals(roleName);
    }
}
