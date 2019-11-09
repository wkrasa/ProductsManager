using FluentValidation;
using FluentValidation.Results;
using ProductsManager.Data;
using ProductsManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsManager.Services.Validators
{
    public class UpdateProductModelValidator : AbstractValidator<UpdateProductModel>
    {
        private readonly IProductService _productService;

        public UpdateProductModelValidator(IProductService productService)
        {
            _productService = productService;
        }

        public override ValidationResult Validate(ValidationContext<UpdateProductModel> context)
        {
            var result = base.Validate(context);

            var productToValidate = context.InstanceToValidate;

            var existingProduct = _productService.GetById(productToValidate.Id);

            if (existingProduct == null)
            {
                var productNotFoundError = new ValidationFailure(nameof(productToValidate.Id), $"Product with id '{productToValidate.Id}' was not found");
                result.Errors.Add(productNotFoundError);
            }
            else 
            {
                existingProduct = _productService.GetByName(productToValidate.Name);

                if (existingProduct != null && existingProduct.Id != productToValidate.Id)
                {
                    var productNameExistsError = new ValidationFailure(nameof(productToValidate.Name), $"Product with name '{productToValidate.Name}' already exists");
                    result.Errors.Add(productNameExistsError);
                }
            }

            return result;
        }
    }
}
