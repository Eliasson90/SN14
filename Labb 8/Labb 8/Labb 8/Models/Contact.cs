using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Labb_8.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "Förnamn måste anges")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Namnet måste vara 3-50 tkn")]
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Efternamnet måste vara 3-50 tkn")]
        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email måste anges")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Inte en godkänd mailadress")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Datum { get; set; }


        public Contact()
        {
            ContactId = Guid.NewGuid();
            Datum = DateTime.Now;
        }
    }

}