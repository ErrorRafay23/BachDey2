using BACH_DEY.Models;
using BACH_DEY.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.Controllers
{
    public class HomeController : Controller
    {


        private readonly IProductRepository _IProductRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
    
        public HomeController(IProductRepository IProductRepository, IWebHostEnvironment hostingEnvironment)
        {
            _IProductRepository = IProductRepository;
            _hostingEnvironment = hostingEnvironment;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = _IProductRepository.GetProducts();
            return View(model);
        }


        public IActionResult AddProduct(ProductCreateViewModel productCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = FileUploader(productCreateViewModel);
                Product model = new Product
                {
                    ID = productCreateViewModel.ID,
                    Title = productCreateViewModel.Title,
                    Description = productCreateViewModel.Description,
                    Brand = productCreateViewModel.Brand,
                    Price = productCreateViewModel.Price,
                    Location = productCreateViewModel.Location,
                    PhoneNo = productCreateViewModel.PhoneNo,
                    IamgePath = uniqueFileName
                };
                _IProductRepository.Add(model);
                return RedirectToAction("Index", new { id = model.ID = productCreateViewModel.ID });
            }
            return View();
        }



        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Product product = _IProductRepository.GetProduct(id);

            ProductEditViewModel model = new ProductEditViewModel
            {
                Id = product.ID,
                Title = product.Title,
                Description = product.Description,
                Brand = product.Brand,
                Price = product.Price,
                Location = product.Location,
                PhoneNo = product.PhoneNo
            };

            return View(model);
        }




        [HttpPost]
        public IActionResult EditProduct(ProductEditViewModel productEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = _IProductRepository.GetProduct(productEditViewModel.Id);

                //product.ID = productEditViewModel.Id;
                product.Title = productEditViewModel.Title;
                product.Description = productEditViewModel.Description;
                product.Brand = productEditViewModel.Brand;
                product.Price = productEditViewModel.Price;
                product.Location = productEditViewModel.Location;
                product.PhoneNo = productEditViewModel.PhoneNo;

                if (productEditViewModel.IformFiles != null)
                {
                    if (productEditViewModel.ExistingPhotoPath != null)
                    {
                        string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "Images", productEditViewModel.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    product.IamgePath = FileUploader(productEditViewModel);
                }
                _IProductRepository.Update(product);
                return RedirectToAction("Index");
            }


            return View();
        }


        public IActionResult Delete(int id)
        {
            _IProductRepository.Delete(id);
            return RedirectToAction("Index");

        }



        private string FileUploader(ProductCreateViewModel poroductCreateViewModel)
        {
            string uniqueFileName = null;
            if (poroductCreateViewModel.IformFiles != null && poroductCreateViewModel.IformFiles.Count > 0)
            {
                foreach (IFormFile photo in poroductCreateViewModel.IformFiles)

                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }
            return uniqueFileName;
        }

    }
}
