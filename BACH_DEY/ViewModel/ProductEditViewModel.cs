using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.ViewModel
{
    public class ProductEditViewModel : ProductCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
