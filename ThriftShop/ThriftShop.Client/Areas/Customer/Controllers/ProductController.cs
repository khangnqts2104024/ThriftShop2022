﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThriftShop.Client.Areas.Customer.ClientModel;
using ThriftShop.Models;

namespace ThriftShop.Client.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private string categoryUrl = "https://localhost:7061/api/Categories/";
        private string productUrl = "https://localhost:7061/api/Products/";
        private string colorUrl = "https://localhost:7061/api/Colors/";
        HttpClient httpClient = new HttpClient();

        public IActionResult Index(string? keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                ProductClientVM productsVM = new ProductClientVM
                {
                    Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(httpClient.GetStringAsync(productUrl + "GetAll/").Result),
                    Categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(httpClient.GetStringAsync(categoryUrl).Result),
                    Colors = JsonConvert.DeserializeObject<IEnumerable<Color>>(httpClient.GetStringAsync(colorUrl).Result)
                };
                return View(productsVM);
            }
            else
            {
                ProductClientVM productsVM = new ProductClientVM
                {
                    Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(httpClient.GetStringAsync(productUrl + "GetAll/" + keyword).Result),
                    Categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(httpClient.GetStringAsync(categoryUrl).Result),
                    Colors = JsonConvert.DeserializeObject<IEnumerable<Color>>(httpClient.GetStringAsync(colorUrl).Result)
                };
                return View(productsVM);
            }
        }
        
        public IActionResult Details(int productId)
        {
            return View();
        }


        public IActionResult Compare()
        {
            return View();
        }

        public IActionResult WishList()
        {
            return View();
        }
    }
}
