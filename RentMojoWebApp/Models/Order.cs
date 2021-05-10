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
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(200)] 
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Deposit")]
        public int Deposit { get; set; }

        [Required]
        [Display(Name = "Monthly Rent")]
        public int MonthlyRent { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]//used foreign key from other class
        [InverseProperty("Orders")]
        public Product Product { get; set; }

    }
}
