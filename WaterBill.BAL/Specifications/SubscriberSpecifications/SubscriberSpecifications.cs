using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.BAL.Specifications.SubscriberSpecifications
{
    public class SubscriberSpecifications : BaseSpecifications<Subscriber>
    {
        public SubscriberSpecifications(OptionsPrams specParams)
            : base(S => (string.IsNullOrEmpty(specParams.Search) || S.Name.ToLower().Contains(specParams.Search))
             || (string.IsNullOrEmpty(specParams.Search) || S.Id.ToLower().Contains(specParams.Search))
            )
        {
            AddIncludes();

            ApplyPagination(specParams.Skip, specParams.PageSize);
        }

        void AddIncludes()
        {
            Includes.Add(S => S.SubscriptionFiles);
        }

    }
}
