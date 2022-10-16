using AutoMapper;
using Ms.Inventory.BusinessLogic.Blo.Inventory;
using Ms.Inventory.BusinessLogic.Contracts.Inventory;
using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Rto.Inventory;
using System;
using System.Threading.Tasks;

namespace Ms.Inventory.BusinessLogic.Inventory
{
    public class InventoryDataService : IInventoryDataService
    {
        private readonly IWriteRepository _writeRepository;
        private readonly IReadRepository _readRepository;
        private readonly IMapper _mapper;

        public InventoryDataService(IWriteRepository writeRepository,
            IReadRepository readRepository,
            IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<int> GetInventoryCountByCompanyAsync(string company)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetInventoryCountByProductAndInventoryIdAsync(int itemReference, string inventoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetInventoryCountByProductPerDayAsync(int itemReference)
        {
            throw new NotImplementedException();
        }

        public async Task SaveInventoryDataAsync(InventoryDataBlo inventoryDataBlo)
        {
            var inventoryDataRto = _mapper.Map<InventoryDataRto>(inventoryDataBlo);
            await _writeRepository.SaveInventoryDataAsync(inventoryDataRto);
        }
    }
}