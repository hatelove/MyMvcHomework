using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Models.CustomValidationAttributes
{
    public class DateBeforeTodayAttribute : RangeAttribute
    {
        public DateBeforeTodayAttribute() : base(typeof(DateTime), DateTime.MinValue.ToString(), DateTime.Today.ToString())
        {
        }
    }
}