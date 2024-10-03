﻿using LegalexApi.BLL.DTO;
using LegalexApi.DAL.Models.OrderAggregate;
using MediatR;


namespace LegalexApi.BLL.BusinessProcesses.SendNotification
{
    public class SendNotificationCommand : IRequest
    {
        public ClientType ClientType { get; set; }
        public Service Service { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }


        public SendNotificationCommand(OrderDTO model)
        {
            ClientType = model.ClientType;
            Service = model.Service;
            Name = model.Name;
            Contact = model.Contact;
            Description = model.Description;
        }
    }
}
