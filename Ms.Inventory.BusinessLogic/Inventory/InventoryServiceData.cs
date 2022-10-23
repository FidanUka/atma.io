using AutoMapper;
using Ms.Inventory.BusinessLogic.Blo.Inventory;
using Ms.Inventory.BusinessLogic.Contracts.Inventory;
using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Rto.Inventory;
using Ms.Inventory.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ms.Inventory.BusinessLogic.Inventory
{
    public class InventoryDataService : IInventoryDataService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public InventoryDataService(IRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Dictionary<string, int> GetInventoryCountGroupedByCompany()
        {
            var items = _repository.GetInventoriedItemsGroupedByCompany();
            try
            {
                return items.ToDictionary(x => x.CompanyName,
                    x => x.Inventory.SelectMany(x => x.Tags).Count());
            }
            catch(Exception)
            {
                //log here ex.Message
                throw;
            }
        }

        public IEnumerable<InventoryPerProductBlo> GetInventoryCountGroupedByProductAndInventoryId()
        {
            var items = _repository.GetInventoriedItemsGroupedByProduct();
            try
            {
                return (from item in items
                        let inventory = item.Items.GroupBy(x => x.InventoryId)
                        .ToDictionary(x => x.Key, x => x.Select(x => x))
                        from inv in inventory
                        select new InventoryPerProductBlo
                        {
                            InventoryId = inv.Key,
                            Items = inv.Value.SelectMany(x => x.Tags).Count(),
                            ProductName = item.ProductName
                        }).ToList();
            }
            catch (Exception)
            {
                //log here ex.Message
                throw;
            }
        }

        public IEnumerable<InventoryProductPerDayBlo> GetInventoryCountGroupedByProductPerDay()
        {
            var items = _repository.GetInventoriedItemsGroupedByProduct();
            try
            {
                return (from item in items
                        let inventory = item.Items.GroupBy(x => x.DateOfInventory.Date)
                        .ToDictionary(x => x.Key, x => x.Select(x => x))
                        from inv in inventory
                        select new InventoryProductPerDayBlo
                        {
                            ProductName = item.ProductName,
                            Items = inv.Value.SelectMany(x => x.Tags).Count(),
                            DateTime = inv.Key
                        }).ToList();
            }
            catch (Exception)
            {
                //log here ex.Message
                throw;
            }
        }

        public void SaveInventoryData(InventoryDataBlo inventoryDataBlo)
        {
            CheckTagsValidity(inventoryDataBlo.Tags);
            ValidateProduct(inventoryDataBlo);
            var inventoryDataRto = _mapper.Map<InventoryDataRto>(inventoryDataBlo);
            _repository.SaveInventoryData(inventoryDataRto);
        }

        #region Helper Methods
        private void CheckTagsValidity(IEnumerable<string> tags)
        {
            try
            {
                //logic here
            }
            catch (TagValidationException)
            {
                //log tags that failed validation
                throw new TagValidationException("Validation for the list of tags failed");
            }
        }

        private void ValidateProduct(InventoryDataBlo inventory)
        {
            var products = _repository.GetProducts();
            if(!products.Any(x=>x.ItemReference == inventory.ItemReference))
            {
                throw new ProductException("Inventory for invalid product");
            }
        }
        #endregion
    }
}