using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class WarehouseBusiness : IWarehouseBusiness
    {
        public readonly InventoryContext _context;

        public WarehouseBusiness(InventoryContext context)
        {
            _context = context;
        }

        public void CreateWarehouse(WarehouseEntity warehouse)
        {
            using (_context)
            {
                _context.Warehouses.Add(warehouse);
                _context.SaveChanges();
            }
        }

        public WarehouseEntity GetWarehouseById(Guid id)
        {
            using (_context)
            {
                IEnumerable<WarehouseEntity> warehouses = from warehouse in _context.Warehouses
                                                          where warehouse.WarehouseId == id
                                                          select warehouse;

                return warehouses.FirstOrDefault();
            }
        }

        public void UpdateWarehouse(WarehouseEntity warehouse)
        {
            using (_context)
            {
                _context.Warehouses.Update(warehouse);
                _context.SaveChanges();
            }
        }

        public List<WarehouseEntity> WarehouseList()
        {
            using (_context)
            {
                return _context.Warehouses.ToList();
            }
        }
    }

    public interface IWarehouseBusiness
    {
        public List<WarehouseEntity> WarehouseList();
        public WarehouseEntity GetWarehouseById(Guid id);
        public void CreateWarehouse(WarehouseEntity warehouse);
        public void UpdateWarehouse(WarehouseEntity warehouse);
    }
}
