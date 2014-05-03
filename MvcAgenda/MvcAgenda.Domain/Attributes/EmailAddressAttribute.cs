using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Reflection;
using System.Linq.Expressions;

namespace MvcAgenda
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)] //Added
    public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string condition;
        private string propertyName; //Added

        public RequiredIfAttribute(string condition)
        {
            this.condition = condition;
           // this.propertyName = propertyName; //Added
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(this.propertyName); //Added
           // Delegate conditionFunction = CreateExpression(validationContext.ObjectType, condition);
           // bool conditionMet = (bool)conditionFunction.DynamicInvoke(validationContext.ObjectInstance);

           // if (conditionMet)
           // {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(null));
            }
           // }

            return ValidationResult.Success;
        }

       // private Delegate CreateExpression(Type objectType, string expression)
       // {
            //LambdaExpression lambdaExpression = System.Linq.Expressions.DynamicExpression.ParseLambda(objectType, typeof(bool), expression); //Added
            //Delegate function = lambdaExpression.Compile();
            //return function;
        //}

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "requiredif",
                ErrorMessage = ErrorMessage //Added
            };

            modelClientValidationRule.ValidationParameters.Add("param", this.propertyName); //Added
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
}