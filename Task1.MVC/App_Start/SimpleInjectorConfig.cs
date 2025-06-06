using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using Task1.MVC.Data;
using Task1.MVC.Services;

namespace Task1.MVC.App_Start
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Регистрация зависимостей
            container.Register<AppDbContext>(Lifestyle.Scoped);
            container.Register<IPersonService, PersonService>(Lifestyle.Scoped);

            // Регистрация всех контроллеров
            container.RegisterMvcControllers(System.Reflection.Assembly.GetExecutingAssembly());

            // Проверка конфигурации
            container.Verify();

            // Установка резолвера зависимостей для MVC
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}