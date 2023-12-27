using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.DAL.Data
{
    public class DataSeeding
    {
        public async static Task DataSeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {

           

           
            //for:  SliceValue
            await AddDateSeedToContext<SliceValue>(context, "SliceValue",  loggerFactory);

            //for:  RrealEstateType
            await AddDateSeedToContext<RrealEstateType>(context, "RrealEstateType", loggerFactory);

            //for:  Subscriber
            await AddDateSeedToContext<Subscriber>(context, "Subscriber",  loggerFactory);


            //for:  Subscription
            await AddDateSeedToContext<Subscription>(context, "Subscription",  loggerFactory);

            //for:  deliveryMethods
            await AddDateSeedToContext<Invoice>(context, "Invoice",  loggerFactory);





        }

        private async static Task AddDateSeedToContext<T>(AppDbContext context, string fileName, ILoggerFactory loggerFactory) where T : class
        {
            if (context.Set<T>().Count() <= 0)
            {
                var items = File.ReadAllText($"../WaterBill.DAL/Data/DataSeed/{fileName}.json");

                 var type = typeof(T);
                 var itemsList = JsonSerializer.Deserialize(items, typeof(List<>).MakeGenericType(type)) as IEnumerable<T>;

                try
                {
                    if (itemsList is not null)
                        foreach (var item in itemsList)
                            context.Set<T>().Add(item);

                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<DataSeeding>();
                    logger.LogError(ex.ToString());
                }
            }
        }



    }
}
