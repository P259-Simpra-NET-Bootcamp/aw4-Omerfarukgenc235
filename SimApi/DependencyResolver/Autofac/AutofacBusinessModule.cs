using Autofac;
using Autofac.Core;
using SimApi.Data.Repository;
using SimApi.Operation;
using SimApi.Operation.TransactionReports;

namespace SimApi.Service.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserLogService>().As<IUserLogService>();
            builder.RegisterType<TokenService>().As<ITokenService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();
            builder.RegisterType<TransactionReportService>().As<ITransactionReportService>();
            builder.RegisterType<DapperAccountService>().As<IDapperAccountService>();
            builder.RegisterType<DapperCategoryService>().As<IDapperCategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();   
        }
    }
}