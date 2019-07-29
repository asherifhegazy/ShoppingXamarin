using eShopApp.Models;
using eShopApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.ViewModels
{
    public class ProductDetailsPageViewModel : BaseViewModel
    {
        public Product Product { get; set; }

        private readonly IProductService _productService;
        private readonly IPageService _pageService;

        public ProductDetailsPageViewModel(int productId, IProductService productService, IPageService pageService)
        {
            _productService = productService;
            _pageService = pageService;

            Product = _productService.GetProductById(productId);
        }
    }
}
