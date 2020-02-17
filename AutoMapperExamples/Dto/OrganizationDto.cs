using System.Collections.Generic;
using AutoMapperExamples.Entity;

namespace AutoMapperExamples.Dto {
    public class OrganizationDto : ContactBaseDto {
        public OrganizationDto() {
            Phones = new List<Phone>();
        }

        public List<Phone> Phones { get; set; }

    }
}