using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentMojoWebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }//primary key created

        [Required]
        [StringLength(1000)]
        [Display(Name = "Delivery Address")]// this code will show address of delivery
        public string Address { get; set; }

        [Display(Name = "Order Date")]//this code will pick order date
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(200)] 
        [Display(Name = "User ID")]
        public string UserID { get; set; }//will pick id of each user

        [Required]
        [Display(Name = "Deposit")]
        public int Deposit { get; set; }////will pick deposit of each user

        [Required]
        [Display(Name = "Monthly Rent")]
        public int MonthlyRent { get; set; }//this code will show monthlyrent

        [Required]
        public int ProductID { get; set; }//this code will pick product id

        [ForeignKey("ProductID")]//used foreign key from other class
        [InverseProperty("Orders")]
        public Product Product { get; set; }

    }
}
