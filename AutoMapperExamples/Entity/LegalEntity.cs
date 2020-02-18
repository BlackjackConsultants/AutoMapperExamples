using System;
using System.Collections.Generic;

namespace AutoMapperExamples.Entity
{
    public class LegalEntity : IEntity
    {
       public ContactBase Contact { get; set; }
        public int Id { get; set; }
    }
}