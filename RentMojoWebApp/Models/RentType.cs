using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentMojoWebApp.Models
{
    public class RentType
    {
        [Key]
        public int TypeID { get; set; }//primary key

        [Required]
        [StringLength(100)]
        [Display(Name = "Type Name")]//this code will show product name
        public string TypeName { get; set; }
         
        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }//code for upload image

        public virtual ICollection<RentSubType> RentSubTypes { get; set; }
    }
}
