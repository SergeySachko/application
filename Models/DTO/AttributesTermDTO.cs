using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTO
{
    public class AttributesTermDTO
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Slug { get; set; }

        [MaxLength(125)]
        public string Description { get; set; }       

        public string ImageUrl { get; set; }

        public AttributesTermDTO Parent { get; set; }

    }
}
