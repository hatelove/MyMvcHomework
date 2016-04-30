using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Models.CustomValidationAttributes
{
    public sealed class AuthorizedPlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //支援 MVC5 新增的 AllowAnonymous
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),
                    inherit: true);

            //有設定 AllowAnonymous 就跳過
            if (skipAuthorization)
            {
                return;
            }

            //驗證是否是授權的連線。
            if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            //驗證是否是授權的連線，並且是 AJAX 呼叫。
            if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                ContentResult cr = new ContentResult();                
                cr.Content = @"<script>alert(""沒有權限進行此動作"")</script>";                
                filterContext.Result = cr;                
            }
        }
    }
}