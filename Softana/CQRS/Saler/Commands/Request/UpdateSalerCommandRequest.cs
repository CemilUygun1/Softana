using System;
using MediatR;
using Softana.CQRS.Saler.Commands.Response;

namespace Softana.CQRS.Saler.Commands.Request
{
    public class UpdateSalerCommandRequest : IRequest<UpdateSalerCommandResponse>
    {
        public int SalerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passwords { get; set; }
        public string Uuser { get; set; }
    }
}