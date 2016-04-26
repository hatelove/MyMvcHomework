using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Models.ViewModels
{
    public class AjaxErrorResultViewModel
    {
        public string ClientId { get; set; }
        public string ErrorMessage { get; set; }
    }
}