﻿using System.Collections.Generic;
using Models=TMD.Web.Models;

namespace TMD.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<Models.ProductCategoryModel>();
        }
        public Models.Product Product { get; set; }
        public IList<Models.ProductCategoryModel> ProductCategories { get; set; }

    }
}