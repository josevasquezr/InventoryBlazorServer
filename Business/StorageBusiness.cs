using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class StorageBusiness : IStorageBusiness
    {
        public readonly InventoryContext _context;

        public StorageBusiness(InventoryContext context)
        {
            _context = context;
        }
        
        public void CreateStorage(StorageEntity storage)
        {
            _context.Storages.Add(storage);
            _context.SaveChanges();
        }

        public StorageEntity GetStorageById(Guid id)
        {
            IEnumerable<StorageEntity> storages = (from storage in _context.Storages
                                                  where storage.StorageId == id
                                                  select storage).Include(p => p.Product);

            return storages.FirstOrDefault();
        }

        public List<StorageEntity> StorageList()
        {
            return _context.Storages.Include(p => p.Product)
                                    .Include(p => p.Warehouse)
                                    .ToList();
        }

        public void UpdateStorage(StorageEntity storage)
        {
            _context.Storages.Update(storage);
            _context.SaveChanges();
        }

        bool IStorageBusiness.IsStorageExist(Guid idProduct, Guid idWarehouse)
        {
            IEnumerable<StorageEntity> storages = from storage in _context.Storages
                                                  where storage.ProductId == idProduct && storage.WarehouseId == idWarehouse
                                                  select storage;

            return storages.Any();
        }
    }

    public interface IStorageBusiness
    {
        public List<StorageEntity> StorageList();
        public StorageEntity GetStorageById(Guid id);
        public void CreateStorage(StorageEntity storage);
        public void UpdateStorage(StorageEntity storage);
        public bool IsStorageExist(Guid idProduct, Guid idWarehouse);
    }
}
