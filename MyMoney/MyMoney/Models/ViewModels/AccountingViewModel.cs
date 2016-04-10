using System;
using MyMoney.Models.Enums;

namespace MyMoney.Models.ViewModels
{
    public class AccountingViewModel
    {
        public int Amount { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Remark { get; internal set; }
        public AccountingType Type { get; internal set; }
    }
}