using MyMoney.Models.Enums;
using MyMoney.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowHistory()
        {
            var history = new List<AccountingViewModel>
            {
                new AccountingViewModel {Type=AccountingType.收入, Amount=10000, Date = new DateTime(2016,4,10), Remark="發傳單" },
                new AccountingViewModel {Type=AccountingType.支出, Amount=4000, Date = new DateTime(2016,4,11), Remark="咖啡" },
                new AccountingViewModel {Type=AccountingType.收入, Amount=91995, Date = new DateTime(2016,5,10), Remark="TDD training" },
            };

            return View(history);
        }
    }
}