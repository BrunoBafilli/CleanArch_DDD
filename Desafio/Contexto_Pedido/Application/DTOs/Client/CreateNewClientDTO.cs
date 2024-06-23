using Domain.Entities.Client.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Client
{
    public class CreateNewClientDTO
    {
        //Propriedades
        public string Name { get; set; }
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }
}
