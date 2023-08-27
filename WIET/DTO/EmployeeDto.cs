using System.ComponentModel.DataAnnotations;
using WIET.Models;

namespace WIET.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,10}$", ErrorMessage = "First Name Must Be Between 3 to 10 charchters")]
        public string FName { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,10}$", ErrorMessage = "Last Name Must Be Between 3 to 10 charchters")]
        public string LName { get; set; }

        [DataType(DataType.Date)]
        [Age]
        public DateTime BirthDate { get; set; }


        public int Gender { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Address { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,25}$", ErrorMessage = "City Name Must Be Between 3 to 25 charchters")]
        public string City { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]{3,25}$", ErrorMessage = "Country Name Must Be Between 3 to 25 charchters")]

        public string Country { get; set; }

        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Enter Valid Postal Code")]
        public int Postal { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [RegularExpression(@"(^01[0125][0-9]{8})$", ErrorMessage = "Invalid phone number, please enter valid phone number")]
        public string Phone { get; set; }

        public int Active { get; set; }
    }
}
