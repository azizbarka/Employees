using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        [Display(Name = "الإسم الأول")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الإسم الأخير")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="تاريخ الميلاد مطلوب")]
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        [Display(Name = "الوظيفة")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "عنوان البريد مطلوب")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        [Display(Name ="العنوان")]
        public string Address { get; set; }
        [Display(Name = "رقم الجوال")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
