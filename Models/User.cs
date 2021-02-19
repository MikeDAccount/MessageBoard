using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// This model is for User information and validating.
namespace MessageBoard.Models
{    
    public class User   // The contructor/class nedds to be manually created with creating a new class file.
    {
        [Key]   // this is a "data annotation" that denotes this is a key identifier. It works specifically with the property that is directly underneath it. In this case Key is making Id the identifier.
        public int Id {get; set; }

        // this is a "data annotation" that denotes this identifier is required, has MinLength. It works specifically with the property that is directly underneath it.
        [Required(ErrorMessage = "Username is required.")]   // ErrorMessage allows a message to show when the data is not valid.                                                           
        [MinLength(2, ErrorMessage = "Username must be at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "Username name must be 20 characters or less.")]
        [Display(Name = "Username")]
        public string Username {get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Emails")]
        public string Email {get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", ErrorMessage = "Password must be 8 characters long and contain at least 1 letter, 1 number and a special character(@$!%*#?&)")]
        [DataType(DataType.Password)]
        [Compare("Confirm", ErrorMessage = "Passwords do not match.")]
        public string Password {get; set; }

        [NotMapped] // This will not prevent this fields information from getting stored somewhere like the database.
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string Confirm {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;
    }

}