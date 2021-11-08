using System;

namespace CharlaDDD.Domain.Exceptions
{
    public class PizzaDomainValidationException : Exception
    {
        public PizzaDomainValidationException(string field, string message)
            : base($"Validation error on field: {field} - Message: {message}") { }
    }

    public class PizzaValidationException : PizzaDomainValidationException
    {
        public PizzaValidationException(string field, string message) : base(field, message) { }
    }

    public class PizzaOrderItemValidationException : PizzaDomainValidationException
    {
        public PizzaOrderItemValidationException(string field, string message) : base(field, message) { }
    }

    public class ReceiverValidationException : PizzaDomainValidationException
    {
        public ReceiverValidationException(string field, string message) : base(field, message) { }
    }

    public class PizzaOrderItemNotFoundException : Exception
    {
        public PizzaOrderItemNotFoundException() : base("Order item not found.") { }
    }
}
