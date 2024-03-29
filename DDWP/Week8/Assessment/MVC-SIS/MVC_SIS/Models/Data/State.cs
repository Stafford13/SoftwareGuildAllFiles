﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State : IValidatableObject
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
         
            if (string.IsNullOrEmpty(StateAbbreviation))
            {
                errors.Add(new ValidationResult("Please enter the state abbreviation (e.g. MN)", new[] { "StateAbbreviation" }));
            }

            return errors;
        }
    }
}