using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentMojoWebApp.Models
{
    public class RentSubType
    {
        [Key]
        public int SubTypeID { get; set; }//primary key created

        [Required]
        [StringLength(100)]
        [Display(Name = "Sub Type Name")] 
        public string SubTypeName { get; set; } //this code will show Sub name

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }//this code will show extention

        [NotMapped]
        public SingleFileUpload File { get; set; }//this code will add image

        [Required]
        public int TypeID { get; set; }

        [ForeignKey("TypeID")]//used foreign key
        [InverseProperty("RentSubTypes")]
        public virtual RentType RentType { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
