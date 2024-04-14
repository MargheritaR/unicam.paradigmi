using FluentValidation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace UnicamParadigmi.Application.Extension
{
    public static  class ValidationExtension
    {
        public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string validationMessage) 
        {
            ruleBuilder.Custom((value, context) =>
            {
                var regEx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$");
                if (regEx.IsMatch(value.ToString()) == false)
                {
                    context.AddFailure(validationMessage);
                }
            });
        }
    }
}
