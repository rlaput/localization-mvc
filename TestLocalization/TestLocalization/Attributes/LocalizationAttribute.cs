using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TestLocalization.Attributes
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "en";

        public LocalizationAttribute(string defaultLanguage)
        {
            this._DefaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"];
            if (lang == null)
            {
                string[] browserLanguages = filterContext.RequestContext.HttpContext.Request.UserLanguages;
                lang =
                    (browserLanguages != null && browserLanguages.Length > 0) ?
                    browserLanguages[0] : _DefaultLanguage;
            }

            try
            {
                Thread.CurrentThread.CurrentCulture =
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                filterContext.Controller.ViewBag.SelectedLanguage = lang;
            }
            catch (Exception e)
            {
                throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
            }
        }
    }
}