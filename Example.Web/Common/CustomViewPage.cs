﻿using System;
using System.Web.Mvc;
using Example.CrossCutting.Security;

namespace Example.Web.Common
{
    public abstract class CustomViewPage<TModel> : WebViewPage<TModel>
    {
        public String DisplayName
        {
            get
            {
                return String.Format("{0} ({1})", User.GetDisplayName(), User.GetUserId());
            }
        }

        protected String ShortDatePatternFormatString
        {
            get
            {
                return "{0:" + ShortDatePattern + "}";
            }
        }

        protected String ShortDatePattern { get { return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern; } }
    }

    public abstract class CustomViewPage : CustomViewPage<dynamic>
    {
    }
}