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
            Mapper.CreateMap<ProductEntity, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, ProductEntity>();
        }
    }
}