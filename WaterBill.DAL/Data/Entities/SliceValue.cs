#nullable disable
using System;
using System.Collections.Generic;

namespace WaterBill.DAL.Data.Entities
{
    public  class SliceValue
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Condition { get; set; }
        public decimal WaterPrice { get; set; }
        public decimal SanitationPrice { get; set; }
        public string Reasons { get; set; }
    }
}