using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace MusicShopWebAPI
{
    public sealed class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object value)
        {
            if (value == null) { return null; }
            string str = value.ToString();
            if (string.IsNullOrEmpty(str)) { return null; }

            //string result = Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower();
            return StringNormalize.Normalize(str, newSymwol: '-');
        }
    }
}
