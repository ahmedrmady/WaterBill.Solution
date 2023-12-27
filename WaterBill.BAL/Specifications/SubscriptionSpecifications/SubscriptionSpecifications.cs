using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.BAL.Specifications.SubscriptionSpecifications
{
    public class SubscriptionSpecifications:BaseSpecifications<Subscription>
    {

        public SubscriptionSpecifications() :base()
        {
            AddIncludes();
        }
        public SubscriptionSpecifications(OptionsPrams specParams)
           :base(S=> (string.IsNullOrEmpty(specParams.Search) || S.Subscriber.Name.ToLower().Contains(specParams.Search))
           || (string.IsNullOrEmpty(specParams.Search) || S.Id.ToLower().Contains(specParams.Search))
           )
        {
            AddIncludes();
            
            ApplyPagination(specParams.Skip,specParams.PageSize);
        }


        void AddIncludes()
        {
            Includes.Add(S => S.RrealEstateType);
            Includes.Add(S => S.Subscriber);
        }

    }
}
