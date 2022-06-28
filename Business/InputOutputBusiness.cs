using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Business
{
    public class InputOutputBusiness : IInputOutputBusiness
    {
        public readonly InventoryContext _context;

        public InputOutputBusiness(InventoryContext context)
        {
            _context = context;
        }
    
        public void CreateInOut(InputOutputEntity inOut)
        {
            _context.InOuts.Add(inOut);
            _context.SaveChanges();
        }

        public InputOutputEntity InOutsById(Guid id)
        {
            IEnumerable<InputOutputEntity> inOuts = from io in _context.InOuts
                                                    where io.InOutId == id
                                                    select io;
            return inOuts.FirstOrDefault();
        }

        public List<InputOutputEntity> InOutsList()
        {
            return _context.InOuts.ToList();
        }

        public void UpdateInOut(InputOutputEntity inOut)
        {
            _context.InOuts.Update(inOut);
            _context.SaveChanges();
        }
    }

    public interface IInputOutputBusiness
    {
        public List<InputOutputEntity> InOutsList();
        public InputOutputEntity InOutsById(Guid id);
        public void CreateInOut(InputOutputEntity inOut);
        public void UpdateInOut(InputOutputEntity inOut);
    }
}
