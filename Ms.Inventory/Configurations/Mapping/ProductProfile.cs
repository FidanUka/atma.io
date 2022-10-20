using AutoMapper;
using Ms.Inventory.BusinessLogic.Blo.Product;
using Ms.Inventory.Database.Rto.Product;
using Ms.Inventory.Dto.Product;

namespace Ms.Inventory.Configurations.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductBlo>();
            CreateMap<ProductBlo, ProductRto>();
        }
    }
}