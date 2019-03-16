using System.Collections.Generic;
using System.Linq;

namespace OnionMessenger.Logic
{
    public class Result
    {
        public bool Success { get; set; }

        public IEnumerable<ErrorMessage> Errors { get; set; }

        //public T Value { get; set; }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>()
            {
                Success = true,
                Value = value
            };
        }

        /*
        public static Result<T> Failure<T>(IEnumerable<ValidationFailure> validationFailures)
        {
            var result = new Result<T>();

            result.Success = false;
            result.Errors = validationFailures.Select(v => new ErrorMessage()
            {
                PropertyName = v.PropertyName,
                Message = v.ErrorMessage
            });

            return result;
        }
        */

        public static Result<T> Failure<T>(IEnumerable<ErrorMessage> errorMessages)
        {
            var result = new Result<T>();

            result.Success = false;
            result.Errors = errorMessages;
            
            return result;
        }

    }

    
    public class Result<T> : Result
    {
        public T Value { get; set; }
    }
    

    public class ErrorMessage
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public ErrorMessage(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;
        }
    }
}
