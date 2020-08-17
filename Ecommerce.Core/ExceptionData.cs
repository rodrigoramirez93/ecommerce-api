using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public class ExceptionData
    {
        public string Code { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
    }

    public class ValidationError
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ValidationExceptionData : ExceptionData
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }
}
