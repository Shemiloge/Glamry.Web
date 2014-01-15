using System.Reflection;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Glamry.BusinessLogic.Helpers;
using Glamry.BusinessLogic.Infrastructures.Fake;
using Glamry.BusinessLogic.Services;
using WebGrease;

namespace Glamry.Web.Infrastructures
{
    public class DependencyResolver
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            //Register All Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>().InstancePerHttpRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();


            builder.RegisterGeneric(typeof(NHibernateRepository<,>)).As(typeof(IRepository<,>)).InstancePerHttpRequest();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerHttpRequest();
            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}