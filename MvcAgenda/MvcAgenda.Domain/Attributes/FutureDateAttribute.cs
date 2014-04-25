using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcAgenda
{
    public class FutureDateAttribute: RequiredAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && value is DateTime && ((DateTime)value) > DateTime.Now;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "requiredif",
                ErrorMessage = ErrorMessage //Added
            };

            //modelClientValidationRule.ValidationParameters.Add("param", this.propertyName); //Added
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
}