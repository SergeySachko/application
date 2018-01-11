using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class SubStatus
    {
        public int Id { get; set; }

        public bool IsBlocked { get; set; }

        public byte Sub { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser  User { get; set; }

        [NotMapped]
        public string TypeSubStr
        {
            get
            {
                switch(Sub)
                {
                    case (byte)TypeOfSub.Full:
                        return "Full";

                    case (byte)TypeOfSub.Middle:
                        return "Middle";

                    case (byte)TypeOfSub.Low:
                        return "Low";

                    default:
                        return null;
                }
            }
        }
    }

    public enum TypeOfSub
    {
        Low = 1,
        Middle = 2,
        Full = 3
    }
}
