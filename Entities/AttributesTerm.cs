using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class ProductAttributeAttributesTerm
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Slug { get; set; }

        [MaxLength(125)]
        public string Description { get; set; }

        public int ParentId { get; set; }

        public virtual ProductAttributeAttributesTerm Parent { get; set; }
    }
}
