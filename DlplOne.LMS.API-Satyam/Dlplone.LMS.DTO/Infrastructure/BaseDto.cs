using Mapster;

namespace Dlplone.LMS.DTO.Infrastructure
{
    public abstract class BaseDto<TDto, TEntity> : IRegister
      where TDto : class, new()
      where TEntity : class, new()
    {

        public TEntity ToEntity()
        {
            return this.Adapt<TEntity>();
        }
        
        public static IEnumerable<TEntity> ToEntities(IEnumerable<TDto> dtos)
        {
            return dtos.Adapt<IEnumerable<TEntity>>();
        }

        public TEntity ToEntity(TEntity entity)
        {
            return (this as TDto).Adapt(entity);
        }

        public static TDto FromEntity(TEntity entity)
        {
            return entity.Adapt<TDto>();
        }
        
        public static IEnumerable<TDto> FromEntities(IEnumerable<TEntity> entities)
        {
            return entities.Adapt<IEnumerable<TDto>>();
        }


        private TypeAdapterConfig Config { get; set; }

        public virtual void AddCustomMappings() { }


        protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings()
            => Config.ForType<TDto, TEntity>();

        protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsInverse()
            => Config.ForType<TEntity, TDto>();

        public void Register(TypeAdapterConfig config)
        {
            Config = config;
            AddCustomMappings();
        }
    }
}
