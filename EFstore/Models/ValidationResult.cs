using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public ValidationResult()
        {

        }
    }

    
}