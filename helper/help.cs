using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wep_proje.helper
{
    public static class help
    {
        public static MvcHtmlString Button(this HtmlHelper htmlHelper, string text)
        {
             string html=string.Format("<button style='float:right;' type='submit' onclick='location.href = '@Url.Action('yeniKayit','admin')'' class='btn btn-primary'>{0}</button>", text);

            return MvcHtmlString.Create(html);
        }
    }
}