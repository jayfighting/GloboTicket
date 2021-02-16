using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace GlobalTicket.TicketManagement.Application.Exceptions
{
    public class ValidationException:ApplicationException
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = validationResult.Errors.Select(err => err.ErrorMessage).ToList();

        }
    }
}