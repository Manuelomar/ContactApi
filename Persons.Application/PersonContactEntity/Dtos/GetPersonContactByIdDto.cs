using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Application.PersonContactEntity.Dtos
{
    internal class GetPersonContactByIdDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }
}
