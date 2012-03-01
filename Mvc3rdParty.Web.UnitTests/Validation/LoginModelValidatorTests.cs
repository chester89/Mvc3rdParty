using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.TestHelper;
using Mvc3rdParty.Web.Models;
using Xunit;

namespace Mvc3rdParty.Web.UnitTests.Validation
{
    public class LoginModelValidatorTests
    {
        private AbstractValidator<LoginModel> validator;
        private LoginModel model;

        public LoginModelValidatorTests()
        {
            validator = new LoginValidator();
            model = new LoginModel()
                        {
                            UserName = "Hey",
                            Password = "pass22"
                        };
        }

        [Fact]
        public void Should_have_error_when_username_is_empty()
        {
            validator.ShouldHaveValidationErrorFor(m => m.UserName, model);
        }

        [Fact]
        public void Should_have_error_when_password_is_too_short()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Password, model);
        }
    }
}
