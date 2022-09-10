using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.ViewModel
{
    public class ProductCreateViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Set a price")]
        [DataType(DataType.Text)]
        public string Price { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        public List<IFormFile> IformFiles { get; set; }
    }
}
