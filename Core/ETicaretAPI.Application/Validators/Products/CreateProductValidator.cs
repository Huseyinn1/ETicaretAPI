﻿using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasınd giriniz");
            RuleFor(c => c.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş geçmeyiniz")
                .Must(s => s >= 0)
                    .WithMessage("stok bilgisi negatif olamaz");
            RuleFor(c => c.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen  fiyat bilgisini boş geçmeyiniz")
                .Must(s => s >= 0)
                    .WithMessage("fiyat  bilgisi negatif olamaz");

        }

    }
}
