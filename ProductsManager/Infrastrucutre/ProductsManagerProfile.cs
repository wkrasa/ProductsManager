using AutoMapper;
using ProductsManager.Data.Models;
using ProductsManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsManager.Infrastrucutre
{
    public class ProductsManagerProfile: Profile
    {
        public ProductsManagerProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
