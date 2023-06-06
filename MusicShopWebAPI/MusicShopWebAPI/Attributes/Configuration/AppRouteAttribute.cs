using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class AppRouteAttribute : RouteAttribute
    {
        public AppRouteAttribute(string template) : base("Music-Shop/api/"+template)
        {
        }
    }
}
