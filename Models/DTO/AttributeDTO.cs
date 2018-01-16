using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class AttributeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int Type { get; set; }

        public List<AttributesTermDTO>  Terms { get; set; }

    }
}
