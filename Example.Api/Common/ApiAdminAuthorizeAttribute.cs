﻿using System;
using System.Web.Http;

using Example.CrossCutting.Security;

namespace Example.Api.Common
{
    /// <summary>
    /// Authorization Attribute für Ressourcen die Admin-Berechtigungen benötigen
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiAdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return actionContext.RequestContext.Principal.IsAdmin();
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}