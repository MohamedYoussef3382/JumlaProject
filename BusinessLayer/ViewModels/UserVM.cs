using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class UserVM
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public Guid PrivilageId { get; set; }
        public string Privilage { get; set; }

        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        //public Guid? UpdatedBy { get; set; }
        //public  DateTime UpdatedOn { get; set; }
    }

    public class SigninVM
    {
        [Required]
        [EmailAddress]
        [StringLength(255, ErrorMessage = "The {0} must be at least {5} characters.", MinimumLength = 5)]
        public string Email { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        public string Password { get; set; }
    }


}
