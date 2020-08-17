using FluentValidation;
using System;
using System.Collections;
using System.Linq;

namespace Ecommerce.Core
{
    public abstract class BaseService
    {
        private readonly string defaultExceptionMessage = "Not known exception";
        private readonly string defaultValidationException = "FLUENT_VALIDATION";
        private readonly string defaultUnknownException = "UNKNOWN";


        //private System.Collections.Generic.List<ValidationError> GetValidationErrors(IDictionary data)
        //{
        //    var result = new System.Collections.Generic.List<ValidationError>();
            
        //    foreach (DictionaryEntry entry in data)
        //    {
        //        result.Add(new ValidationError() { Name = (string) entry.Key, Description = (string) entry.Value });
        //    }

        //    return result;
        //}

        //public T Service<T>(Func<T> action) where T : class
        //{
        //    try
        //    {
        //        return action();
        //    }
        //    catch(ValidationException validationException)
        //    {
        //        //known exception
        //        var exceptionData = new ValidationExceptionData()
        //        {
        //            Code = defaultValidationException,
        //            ExceptionMessage = validationException?.Message ?? defaultExceptionMessage,
        //            InnerExceptionMessage = validationException?.InnerException?.Message ?? defaultExceptionMessage,
        //            ValidationErrors = GetValidationErrors(validationException.Data)
        //        };
                
                
        //    }
        //    //catch(Exception businessException) 
        //    //{
        //    //    //known exception
        //    //    //var exceptionData = new ExceptionData()
        //    //    //{
        //    //    //    Code = businessException.Code,
        //    //    //    ExceptionMessage = businessException,
        //    //    //    InnerExceptionMessage = businessException,
        //    //    //}

        //    //    throw new Exception();
        //    //}
        //    //catch (NotFiniteNumberException exception)
        //    //{
        //    //    //unknown exception
        //    //    var exceptionData = new ExceptionData()
        //    //    {
        //    //        Code = defaultUnknownException,
        //    //        ExceptionMessage = exception?.Message ?? defaultExceptionMessage,
        //    //        InnerExceptionMessage = exception?.InnerException?.Message ?? defaultExceptionMessage,
        //    //    };

        //    //    throw new Exception();

        //    //}
        //}
    }
}
