using MyMoney.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models.ViewModels
{
    public class AccountingViewModel
    {
        //[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:N0}")]
        public int Amount { get; internal set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; internal set; }

        public string Remark { get; internal set; }
        public AccountingType Type { get; internal set; }
    }
}