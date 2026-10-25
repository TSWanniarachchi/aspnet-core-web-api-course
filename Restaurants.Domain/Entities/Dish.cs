using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public int Name { get; set; } = default!;
        public int Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
