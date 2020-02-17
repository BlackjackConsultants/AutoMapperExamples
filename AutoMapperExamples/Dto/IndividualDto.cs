using System;
using System.Collections.Generic;
using AutoMapperExamples.Entity;

namespace AutoMapperExamples.Dto {
    public class IndividualDto : ContactBaseDto {
        public IndividualDto() {
            Phones = new List<Phone>();
        }

        public string FName { get; set; }
        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }

        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public string FileAs { get; set; }

    }
}