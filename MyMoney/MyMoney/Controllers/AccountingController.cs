using MyMoney.Models;
using MyMoney.Models.Enums;
using MyMoney.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class AccountingController : Controller
    {
        private AccountingModels accountDbContext = new AccountingModels();

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AccountingViewModel pageData)
        {
            if (!ModelState.IsValid)
            {
                return View(pageData);
            }

            var accountBook = new AccountBook
            {
                Amounttt = pageData.Amount,
                Categoryyy = (int)pageData.Type,
                Dateee = pageData.Date,
                Remarkkk = pageData.Remark,
                Id = Guid.NewGuid()
            };

            this.accountDbContext.AccountBook.Add(accountBook);
            this.accountDbContext.SaveChanges();

            return RedirectToAction("Add");
        }

        [ChildActionOnly]
        public ActionResult ShowHistory()
        {
            var accountingBooks = this.accountDbContext.AccountBook
                .OrderByDescending(x => x.Dateee)
                .Take(10)
                .Select(x =>
                new AccountingViewModel
                {
                    Amount = x.Amounttt,
                    Date = x.Dateee,
                    Remark = x.Remarkkk,
                    Type = (AccountingType)x.Categoryyy
                });

            return View(accountingBooks);
        }

        protected override void Dispose(bool disposing)
        {
            accountDbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}