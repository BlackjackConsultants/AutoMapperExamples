using AutoMapper;
using AutoMapper.Mappers;

namespace AutoMapperExamples.Mappers {
    /// <summary>
    /// using this wrapper allows for several configuration from same entity and dto.  for each configuration 
    /// create a mapper.  there should be a mapper per entity and dto.
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class MapperBase<TDto, TEntity> 
        where TDto : IDto where TEntity : IEntity {

            protected MappingEngine MapEngine { get; set; }

        private void Initialize() {
            var configurationStore = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            CreateMaps(configurationStore);
            MapEngine = new MappingEngine(configurationStore);
        }

        /// <summary>
        /// In this method Maps are created.
        /// </summary>
        /// <param name="store"></param>
        protected abstract void CreateMaps(ConfigurationStore store);

        public TDto Map(TEntity entity) {
            if (MapEngine == null) {
                Initialize();
            }

            if (MapEngine != null) 
                return MapEngine.Map<TEntity, TDto>(entity);
            return default(TDto); ;
        }

        public TEntity Map(TDto dto) {
            if (MapEngine == null) {
                Initialize();
            }
            if (MapEngine != null) 
                return MapEngine.Map<TDto, TEntity>(dto);
            return default(TEntity); ;
        }
    }
}