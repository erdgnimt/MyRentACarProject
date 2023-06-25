using Core.Entites;
using System;

namespace Entites.DTOs
{
    public class RentalDetailDto : IEntity
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }        
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
