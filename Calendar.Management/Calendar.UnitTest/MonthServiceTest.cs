using AutoMapper;
using Calendar.Dal;
using Calendar.Dal.Impl;
using Calendar.Dal.Interface;
using Calendar.Services;
using Calendar.Services.Impl;
using Calendar.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.UnitTest
{
    public class MonthServiceTest
    {
        IMonthService _monthService;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            
            Register.ConfigureServices(services); // Initialise Database
            InitialiseAutoMapper(services);
            InitialiseMonthRepo(services);
            InitialiseLogger(services);
            InitialiseMonthService(services);
        }

        
        [Test]
        public async Task Get_Months()
        {
            var result = await _monthService.GetAsync();

            Assert.IsNotNull(result);
            Assert.IsNull(result.ErrorMessage);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Months.Count(), 12);
        }


        #region Initialise service and database
        private void InitialiseDatabase(ServiceCollection services)
        {
            services.AddDbContext<CalendarDbContext>(opt =>
                                                   opt.UseInMemoryDatabase("CalendarManagement"));

        }

        private void InitialiseAutoMapper(ServiceCollection services)
        {


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void InitialiseMonthRepo(ServiceCollection services)
        {
            services.AddTransient<IMonthRepository, MonthRepository>();
        }
        private void InitialiseLogger(ServiceCollection services)
        {
            services.AddLogging();
        }
        private void InitialiseMonthService(ServiceCollection services)
        {
            services.AddTransient<IMonthService, MonthService>();
            var serviceProvider = services.BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            serviceProvider.GetService<IDbInitializer>().SeedData();
            _monthService = serviceProvider.GetService<IMonthService>();
        }
        #endregion
    }
}