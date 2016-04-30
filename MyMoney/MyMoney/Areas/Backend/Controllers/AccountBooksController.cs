using MyMoney.Models;
using MyMoney.Models.CustomValidationAttributes;
using MyMoney.Models.Enums;
using MyMoney.Models.ViewModels;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyMoney.Areas.Backend.Controllers
{
    [AuthorizeForBackend(Users = "jay.hatelove@gmail.com")]
    public class AccountBooksController : Controller
    {
        private AccountingModels db = new AccountingModels();

        // GET: Backend/AccountBooks
        public ActionResult Index()
        {
            var models = db.AccountBook.OrderByDescending(x => x.Dateee).Take(20)
                .ToList()
                .Select(x => MapAccoutBookToAccountingViewModel(x));

            return View(models);
        }

        // GET: Backend/AccountBooks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = this.MapAccoutBookToAccountingViewModel(accountBook);
            return View(viewModel);
        }

        // GET: Backend/AccountBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Backend/AccountBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Amount,Date,Remark")] AccountingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var accountBook = this.MapAccountingViewModelToAccountBook(viewModel);

                accountBook.Id = Guid.NewGuid();
                db.AccountBook.Add(accountBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Backend/AccountBooks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = this.MapAccoutBookToAccountingViewModel(accountBook);
            return View(viewModel);
        }

        private AccountingViewModel MapAccoutBookToAccountingViewModel(AccountBook accountBook)
        {
            return new AccountingViewModel
            {
                Amount = accountBook.Amounttt,
                Date = accountBook.Dateee,
                Remark = accountBook.Remarkkk,
                Type = (AccountingType)accountBook.Categoryyy,
                Id = accountBook.Id
            };
        }

        private AccountBook MapAccountingViewModelToAccountBook(AccountingViewModel viewModel)
        {
            return new AccountBook
            {
                Id = viewModel.Id,
                Amounttt = viewModel.Amount,
                Categoryyy = (int)viewModel.Type,
                Dateee = viewModel.Date,
                Remarkkk = viewModel.Remark
            };
        }

        // POST: Backend/AccountBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Amount,Date,Remark")] AccountingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var accountBook = this.MapAccountingViewModelToAccountBook(viewModel);
                db.Entry(accountBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Backend/AccountBooks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = this.MapAccoutBookToAccountingViewModel(accountBook);
            return View(viewModel);
        }

        // POST: Backend/AccountBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBook accountBook = db.AccountBook.Find(id);
            db.AccountBook.Remove(accountBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}