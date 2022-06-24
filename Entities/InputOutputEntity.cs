using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class InputOutputEntity
    {
        public Guid InOutId { get; set; }
        public Guid StorageId { get; set; }
        public DateTime InOutDate { get; set; }
        public int Quantity { get; set; }
        public bool IsInput { get; set; }
        public StorageEntity Storage { get; set; }
    }
}
