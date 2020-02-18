using System;
using System.Collections.Generic;

namespace AutoMapperExamples.Entity
{
    public class LegalEntityDto : IDto
    {
       public ContactBase Contact { get; set; }
        public int Id { get; set; }
    }
}