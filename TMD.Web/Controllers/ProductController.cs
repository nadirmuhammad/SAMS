﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Product;

namespace TMD.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        
        // GET: /Product/
        public ActionResult Index()
        {
            List<TMD.Web.Models.Product> Products =
                productService.GetAllProducts()
                    .ToList()
                    .Select(x => x.MapServerToClient()).ToList();

            return View(Products);
        }
        
        // GET: /Product/Create
        public ActionResult Create(int ?ID)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            var prodResp = productService.GetProductResponse(ID);
            if (prodResp.Product != null)
            {
                productViewModel.Product = prodResp.Product.MapServerToClient();
            }
            else
            {
                productViewModel.Product = new Models.Product();
            }

            productViewModel.ProductCategories = prodResp.ProductCategories.Select(x => x.MapServerToClient()).ToList();

            return View(productViewModel);
        }
        
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                productViewModel.Product.UpdatedDate = DateTime.UtcNow;
                productViewModel.Product.UpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (productViewModel.Product.ProductID > 0)
                {
                    productService.UpdateProduct(productViewModel.Product.MapClientToServer());
                }
                else
                {
                    productViewModel.Product.CreatedDate = DateTime.UtcNow;
                    productViewModel.Product.CreatedBy = User.Identity.GetUserId();

                    productService.AddProduct(productViewModel.Product.MapClientToServer());
                }

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        public ActionResult ModelSpecs(int? ID)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            var prodResp = productService.GetProductResponse(ID);
            if (prodResp.Product != null)
            {
                productViewModel.Product = prodResp.Product.MapServerToClient();
            }
            else
            {
                productViewModel.Product = new Models.Product();
            }

            productViewModel.ProductCategories = prodResp.ProductCategories.Select(x => x.MapServerToClient()).ToList();

            return View(productViewModel);
        }
        
        [HttpPost]
        public ActionResult ModelSpecs(ProductViewModel productViewModel)
        {
            try
            {
                productViewModel.Product.UpdatedDate = DateTime.UtcNow;
                productViewModel.Product.UpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (productViewModel.Product.ProductID > 0)
                {
                    productService.UpdateProduct(productViewModel.Product.MapClientToServer());
                }
                else
                {
                    productViewModel.Product.CreatedDate = DateTime.UtcNow;
                    productViewModel.Product.CreatedBy = User.Identity.GetUserId();

                    productService.AddProduct(productViewModel.Product.MapClientToServer());
                }

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}