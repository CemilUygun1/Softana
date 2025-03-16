using System;
using MediatR;
using Softana.CQRS.Saler.Commands.Response;
using Softana.Models;

namespace Softana.CQRS.Saler.Commands.Request
{
    public class UpdateSalerCommandRequest : IRequest<UpdateSalerCommandResponse>
    {
        public int SalerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Uuser { get; set; }
        public DateTime? Udate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

        public  List<SalerDetail> SalerDetails { get; set; }
    }
}