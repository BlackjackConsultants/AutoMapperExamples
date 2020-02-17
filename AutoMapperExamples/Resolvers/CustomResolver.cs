using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperExamples.Entity;

namespace AutoMapperExamples.Resolvers {
    public class CustomResolver : ValueResolver<Source, int> {
        protected override int ResolveCore(Source source) {
            return source.Value1 + source.Value2;
        }
    }

}
