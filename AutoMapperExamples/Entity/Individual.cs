using System;
using System.Collections.Generic;

namespace AutoMapperExamples.Entity
{
    public class Individual : ContactBase, IEntity
    {
        public Individual()
        {
            Phones = new List<Phone>();
        }

        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }

        public DateTime BirthDate { get; set; }

        public double Height { get; set; }
        public string FileAs { get; set; }
    }
}