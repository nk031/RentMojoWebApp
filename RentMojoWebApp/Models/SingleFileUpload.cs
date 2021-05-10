using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentMojoWebApp.Models
{
    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]//this code will pick image from folder
        public IFormFile FormFile { get; set; }
    }
}
 