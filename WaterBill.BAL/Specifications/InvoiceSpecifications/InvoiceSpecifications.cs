using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.BAL.Specifications.InvoiceSpecifications
{
    public class InvoiceSpecifications:BaseSpecifications<Invoice>
    {
        public InvoiceSpecifications(OptionsPrams specParams)
            : base(S => (string.IsNullOrEmpty(specParams.Search) || S.Subscriber.Name.ToLower().Contains(specParams.Search))
             || (string.IsNullOrEmpty(specParams.Search) || S.Id.ToLower().Contains(specParams.Search))
            )
        {
            AddIncludes();
            ApplyPagination(specParams.Skip, specParams.PageSize);
          
        }
        private void AddIncludes()
        {
            // add 
            Includes.Add(I => I.Subscription);
            Includes.Add(I => I.Subscriber);
        }
    }
}
