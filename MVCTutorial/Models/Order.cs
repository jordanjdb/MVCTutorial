using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models
{
    public class Order : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LastName.ToString().Where(chr => chr.ToString() == " ").Count() + 1 > 3)
            {
                yield return new ValidationResult("The last name has too many words!", new[] { "LastName" });
            }
            if (Username == FirstName)
            {
                var ErrorString = string.Format("{0} and {1} cannot be the same.", "Username", "First Name");

                yield return new ValidationResult(ErrorString, new[] { "Username", "FirstName" });
            }
        }

        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Compare("Email")]
        public string EmailConfirm { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [ReadOnly(true)]
        public decimal Total { get; set; }

    }
}