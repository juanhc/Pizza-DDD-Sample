using CharlaDDD.Domain.Exceptions;
using CharlaDDD.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharlaDDD.Domain.Aggregates.PizzaOrder
{
    public class Receiver : ValueObject
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }

        public Receiver(string name, string lastName, string phoneNumber)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ReceiverValidationException(nameof(name), $"{nameof(name)} is mandatory") : name;
            LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ReceiverValidationException(nameof(lastName), $"{nameof(lastName)} is mandatory") : lastName;
            PhoneNumber = phoneNumber.IsPhoneNumber() ? phoneNumber : throw new ReceiverValidationException(nameof(phoneNumber), $"{nameof(phoneNumber)} must be a phone number.");
        }

        protected override IEnumerable<object> GetAtomicValues() => new List<object> { Name, LastName, PhoneNumber };
    }
}
