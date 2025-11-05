using FluentValidation;
using MiniInventory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Application.FluentValidation
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {

        public CreateProductDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required").MaximumLength(250);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
