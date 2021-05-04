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
        public int SubTypeID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Sub Type Name")] 
        public string SubTypeName { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }

        [Required]
        public int TypeID { get; set; }

        [ForeignKey("TypeID")]
        [InverseProperty("RentSubTypes")]
        public virtual RentType RentType { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
