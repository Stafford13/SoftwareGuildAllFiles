﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> errors = new List<ValidationResult>();
        //    if (MajorId == 0)
        //    {
        //        errors.Add(new ValidationResult("Please select a major", new[] { "MajorId" }));
        //    }

        //    return errors;
        //}
    }
}