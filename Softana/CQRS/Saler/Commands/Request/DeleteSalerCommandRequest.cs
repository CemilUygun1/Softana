using System;
using MediatR;
using Softana.CQRS.Saler.Commands.Response;

namespace Softana.CQRS.Saler.Commands.Request
{
    public class DeleteSalerCommandRequest : IRequest<DeleteSalerCommandResponse>
    {
        public int SalerId { get; set; }
        public string Duser { get; set; }
    }
}