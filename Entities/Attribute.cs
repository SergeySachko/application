using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductAttribute
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int Type { get; set; }

        public virtual ICollection<ProductAttributeAttributesTerm> Terms { get; set; }
    }
}
