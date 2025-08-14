using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.DTOs.Response
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateOnly Birthday { get; set; }

        public string? BirthPlace { get; set; }

        public string Role { get; set; } = string.Empty;

        public PlayerRole RoleEnum { get; set; } 

    }
}