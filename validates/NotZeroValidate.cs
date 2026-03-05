using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace prakt8_wpf.validates
{
    public class NotZeroValidate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Поле не может быть пустым");
            }
            return ValidationResult.ValidResult;
        }
    }
}
