﻿using MyMoney.Models.Enums;
using MyMoney.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class AccountingController : Controller
    {
        private static List<AccountingViewModel> accountings = new List<AccountingViewModel>
            {
                new AccountingViewModel {Type=AccountingType.收入, Amount=10000, Date = new DateTime(2016,4,10), Remark="發傳單" },
                new AccountingViewModel {Type=AccountingType.支出, Amount=4000, Date = new DateTime(2016,4,11), Remark="咖啡" },
                new AccountingViewModel {Type=AccountingType.收入, Amount=91995, Date = new DateTime(2016,5,10), Remark="TDD training" },
            };
              
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AccountingViewModel pageData)
        {            
            accountings.Add(pageData);
            ModelState.Clear();
            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowHistory()
        {
            return View(accountings);
        }
    }
}