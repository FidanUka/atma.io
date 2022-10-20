using AutoMapper;
using Ms.Inventory.BusinessLogic.Blo.Inventory;
using Ms.Inventory.Database.Rto.Inventory;
using Ms.Inventory.Dto.Inventory;

namespace Ms.Inventory.Configurations.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDataDto, InventoryDataBlo>();
            CreateMap<InventoryDataBlo, InventoryDataRto>();
            CreateMap<InventoryPerProductBlo, InventoryPerProductDto>();
            CreateMap<InventoryProductPerDayBlo, InventoryProductPerDayDto>();
        }
    }
}