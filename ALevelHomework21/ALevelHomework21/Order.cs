using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework21
{
    public class Order
    {
        public int Id { get; set; }
        public UserEntity? User { get; set; }
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }
}
