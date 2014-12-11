using AutoMapper;

using TDS.DataAccess.EntityModels;
using TDS.Presentation.Ui.Models;

namespace TDS.Presentation.Ui
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<CategoryEntity, CategoryViewModel>().ReverseMap();

            Mapper.CreateMap<ProductEntity, ProductViewModel>().ReverseMap();

            Mapper.CreateMap<ProviderEntity, ProviderViewModel>().ReverseMap();

            Mapper.CreateMap<DeliveryEntity, DeliveryViewModel>().ReverseMap();
        }
    }
}