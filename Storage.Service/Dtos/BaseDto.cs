using System;
using Storage.Service.Interfaces;

namespace Storage.Service.Dtos
{
    public class BaseDto: IDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}