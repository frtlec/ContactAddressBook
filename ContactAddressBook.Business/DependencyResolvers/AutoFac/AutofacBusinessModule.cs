using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ContactAddressBook.Business.Abstract;
using ContactAddressBook.Business.Concrete;
using ContactAddressBook.DataAccessLayer.Abstract;
using ContactAddressBook.DataAccessLayer.Concrete.EntityFramework;
using Core.Utilities.Interceptors;
using Core.Utilities.Security;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonManager>().As<IPersonService>();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>().SingleInstance();


            builder.RegisterType<ContactInfoManager>().As<IContactInfoService>();
            builder.RegisterType<EfContactInfoDal>().As<IContactInfoDal>().SingleInstance();


            //builder.RegisterType<UserManager>().As<IUserService>();
            //builder.RegisterType<EfUserDal>().As<IUserDal>();

            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
