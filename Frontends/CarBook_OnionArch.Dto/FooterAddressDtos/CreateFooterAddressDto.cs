using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_OnionArch.Dto.FooterAddressDtos
{
    public class CreateFooterAddressDto
    {
        public required string Description { get; set; }
        public required string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
