using AutoMapper;
using ProductsManager.Data.Models;
using ProductsManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsManager.Services
{
    public class ProductsManagerProfile: Profile
    {
        public ProductsManagerProfile()
        {
            CreateMap<Product, ProductDTO>();

            CreateMap<Product, CreateProductModel>();

            CreateMap<Product, UpdateProductModel>();
        }
    }
}
