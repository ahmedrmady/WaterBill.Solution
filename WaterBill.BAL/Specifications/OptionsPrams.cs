using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterBill.BAL.Specifications
{
    public class OptionsPrams
    {

        #region Attributes
        private int _pageSize = 10;
        private string? search;

        #endregion

        public int PageSize { get => _pageSize; set => _pageSize = value; }

        public int Skip { get; set; }



        public string? Sort { get; set; }



        public string? Search { get => search; set => search = value.ToLower(); }



    }
}
