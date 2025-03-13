using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace AuthApi.Models.DTOs
{
    public class LoginValidate : AbstractValidator<UserLoginDto>
    {
        public LoginValidate()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email không được để trống")
            .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password không được để trống");
        }
    }
}