﻿using System.Web;
using System.Web.Mvc;
using TestLocalization.Attributes;

namespace TestLocalization
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("en"), 0);
        }
    }
}
