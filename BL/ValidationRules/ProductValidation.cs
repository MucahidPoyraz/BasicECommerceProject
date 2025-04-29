using Entities.Concrete;
using FluentValidation;

namespace BL.ValidationRules
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(blog => blog.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur.")
                .Length(5, 500).WithMessage("Açıklama 5 ile 500 karakter arasında olmalıdır.");

            RuleFor(blog => blog.Stock)
                .NotEmpty().WithMessage("Stok zorunludur.");
        }
    }
}
