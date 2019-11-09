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
    public class CreateProductModelValidator: AbstractValidator<CreateProductModel>
    {
        private readonly IProductService _productService;

        public CreateProductModelValidator(IProductService productService)
        {
            _productService = productService;
        }

        public override ValidationResult Validate(ValidationContext<CreateProductModel> context)
        {
            var result = base.Validate(context);

            var productToValidate = context.InstanceToValidate;

            var existingProduct = _productService.GetByName(productToValidate.Name);

            if (existingProduct != null)
            {
                var error = new ValidationFailure(nameof(productToValidate.Name), $"Product with name '{productToValidate.Name}' already exists");
                result.Errors.Add(error);
            }

            return result;
        }
    }
}
