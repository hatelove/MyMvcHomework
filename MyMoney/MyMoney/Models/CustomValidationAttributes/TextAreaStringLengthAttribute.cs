using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MyMoney.Models.CustomValidationAttributes
{
    public class TextAreaStringLengthAttribute : ValidationAttribute
    {
        private int _length;

        public TextAreaStringLengthAttribute(int length)
        {
            this._length = length;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, this.ErrorMessageString, name, this._length);
        }

        public override bool IsValid(object value)
        {
            var text = (string)value;
            return text.Length <= this._length;
        }
    }
}