using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.DTOs.DTOs.Request
{
    public class EditPlayer
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateOnly? Birthday { get; set; }

        public string? BirthPlace { get; set; }

        public PlayerRole? Role { get; set; }
    }
}