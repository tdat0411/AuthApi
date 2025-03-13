using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace AuthApi.Models.DTOs
{
    public class RegisterValidate : AbstractValidator<UserRegisterDto>
    {
        public RegisterValidate()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên không được để trống");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email không được để trống")
            .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password không được để trống")
            .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tự");

            RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Số điện thoại không được để trống")
            .Matches(@"^\d{10}$").WithMessage("Số điện thoại không hợp lệ");
        }
    }
}