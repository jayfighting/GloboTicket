﻿using System.Collections.Generic;
using GloboTicket.TicketManagement.Domain.Common;

namespace GloboTicket.TicketManagement.Domain.ValueObjects
{
        public class Address : ValueObject
        {
            public string Street { get; }
            public string City { get; }
            public string ZipCode { get; }

            public Address(string street, string city, string zipCode)
            {
                Street = street;
                City = city;
                ZipCode = zipCode;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Street;
                yield return City;
                yield return ZipCode;
            }
        }
}
