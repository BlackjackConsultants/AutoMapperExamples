using System;
using System.Collections.Generic;

namespace AutoMapperExamples.Entity
{
    public class Organization : ContactBase, IEntity
    {
        public Organization()
        {
            Phones = new List<Phone>();
        }

        public List<Phone> Phones { get; set; }


    }
}