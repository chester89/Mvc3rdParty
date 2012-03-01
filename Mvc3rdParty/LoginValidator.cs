using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Mvc3rdParty.Web.Models;

namespace Mvc3rdParty.Web
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(m => m.UserName).Length(4, 30).WithLocalizedMessage(() => ValidationMessages.Login_UserName_ShouldBeOfLength);
            RuleFor(m => m.Password).Length(8, 30).WithLocalizedMessage(() => ValidationMessages.Login_Password_ShouldHaveLength);
        }
    }
}