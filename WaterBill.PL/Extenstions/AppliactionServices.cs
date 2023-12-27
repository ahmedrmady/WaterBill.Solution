using WaterBill.BAL;
using WaterBill.BAL.Interfaces;
using WaterBill.BAL.Repoistories;
using WaterBill.PL.Helpers;
using WaterBill.SAL.Interfaces;
using WaterBill.SAL.Services;

namespace WaterBill.PL.Extenstions
{
    public static class AppliactionServices
    {
        public static IServiceCollection AddApplactionServices(this IServiceCollection services)
        {


           // services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IServiceWithSpecs<>),typeof(ServiceWithSpecs<>));
            services.AddScoped(typeof(IWaterBillService),typeof(WaterBillService));
            return services;
        }
    }
}
