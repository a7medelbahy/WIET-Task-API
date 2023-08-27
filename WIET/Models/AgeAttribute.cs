using System.ComponentModel.DataAnnotations;

namespace WIET.Models
{
    public class AgeAttribute:ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;


        public AgeAttribute()
        {
            _minDate = new DateTime(1963, 1, 1);
            _maxDate = new DateTime(2003, 1, 1);

        }

        public override bool IsValid(object value)
        {

            DateTime dateTime = (DateTime)value;
            return dateTime >= _minDate && dateTime <= _maxDate;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} Employee Age must be between 20 and 60 years";
        }
    }
}
