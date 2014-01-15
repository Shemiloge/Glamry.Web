using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glamry.Web.Models
{
    public class RegistrationModel
    {
        public bool IsEditting { get; set; }

        public RegistrationModel()
        {
            this.SystemRoles = new List<SelectListItem>();
        }

        public long Id { get; set; }
        public Guid UserId { get; set; }

        [DisplayName("User Role:")]
        public string UserRole { get; set; }

        public List<SelectListItem> SystemRoles { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        [DisplayName("New Password:")]
        [StringLength(160, MinimumLength = 8, ErrorMessage = "Password lenght cannot be less than 8 characters")]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$",
            ErrorMessage = "Password must be alphanumeric")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        [StringLength(160, MinimumLength = 8, ErrorMessage = "Password lenght cannot be less than 8 characters")]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$",
            ErrorMessage = "Password must be alphanumeric")]
        [DisplayName("Confirm Password:")]
        public string ConfirmPassword { get; set; }


        [DisplayName("First Name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string LastName { get; set; }

        [DisplayName("User Name:")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Enter a valid Email Address")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Email { get; set; }

        [DisplayName("Upload Picture:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string ImageUpload { get; set; }

        [DisplayName("Phone Number:")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number not valid")]
        [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){2,}$", ErrorMessage = "Phone number not valid")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
    }
}
