using Autofac;
using AutoMapper;
using HR.Application.AutoMapper;
using HR.Application.Services.AdminService;
using HR.Application.Services.AdvanceService;
using HR.Application.Services.MailService;
using HR.Application.Services.ManagerService;
using HR.Application.Services.UserService;
using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace HR.Application.IoC
{
    public class DependencyResolver :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
			//Repository 
			builder.RegisterType<CompanyRepo>().As<ICompanyRepo>().InstancePerLifetimeScope();
			builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserAdvanceRepo>().As<IUserAdvanceRepo>().InstancePerLifetimeScope();



            //Services
            builder.RegisterType<MailService>().As<IMailService>().InstancePerLifetimeScope();
            builder.RegisterType<AdvanceService>().As<IAdvanceService>().InstancePerLifetimeScope();
            builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();
			builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
			builder.RegisterType<ManagerService>().As<IManagerService>().InstancePerLifetimeScope();






			//AUTOMAPPER
			builder.Register(context => new MapperConfiguration(cfg =>
            {
              cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //daha sonra kullanılabilecek yeni bağlamlar için
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
