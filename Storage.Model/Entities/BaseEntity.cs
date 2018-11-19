using System;
using System.Collections.Generic;
using System.Text;
using Storage.Common.Interfaces;

namespace Storage.Model.Entities
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
