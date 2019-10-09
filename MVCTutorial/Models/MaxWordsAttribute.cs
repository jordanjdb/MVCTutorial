using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutorial.Models
{
    public class MaxWordsAttribute : ValidationAttribute,
									 IClientValidatable
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords)
            : base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {

			var rule = new ModelClientValidationRule {
				ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
				ValidationType = "maxwords"
			};
			rule.ValidationParameters.Add("wordcount", _maxWords);
			
			yield return rule;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (value != null)
            {
                if (value.ToString().Where(chr => chr.ToString() == " ").Count() + 1 > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                    //return new ValidationResult("Too many Words");
                }
            }
            return ValidationResult.Success;
        }
    }
}