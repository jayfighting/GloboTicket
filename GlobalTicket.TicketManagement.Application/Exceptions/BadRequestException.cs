﻿using System;

namespace GlobalTicket.TicketManagement.Application.Exceptions
{
    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string message):base(message)
        {
            
        } 
    }
}