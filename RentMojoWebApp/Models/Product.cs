using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentMojoWebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }//primary key

        [Required]
        [StringLength(200)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } //this code will show product name

        [Required]
        [StringLength(200)]
        [Display(Name = "Shipping Days")]//this code will show shipping day
        public string TagLine { get; set; }

        [Required]
        [Display(Name = "Deposit")]
        public int Deposit { get; set; }//this code will show product deposit 

        [Required]
        [Display(Name = "Monthly Rent")]
        public int MonthlyRent { get; set; }//this code will show product monthly rent

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }//this code will show extension

        [Required]
        public int SubTypeID { get; set; }

        [ForeignKey("SubTypeID")]//used foreign key
        [InverseProperty("Products")]
        public virtual RentSubType RentSubType { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }//this code will image from folder

        public virtual ICollection<Order> Orders { get; set; }
    }
}
