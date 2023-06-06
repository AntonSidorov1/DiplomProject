using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Фильтр катероий
    /// </summary>
    public class CategoryFilter : Part
    {


        public virtual bool EqualsName(string name)
        {
            if (this.Name == name)
                return true;
            if (StringNormalize.Normalize(this.Name, formatEnd: FormatEnd.None) == StringNormalize.Normalize(name, formatEnd: FormatEnd.None))
                return true;
            return false;
        }

    }
}
