using Nancy.TinyIoc;
using Nancy;

namespace Backend
{
     public class Bootstrapper : DefaultNancyBootstrapper
     {
         protected override void ConfigureApplicationContainer(TinyIoCContainer container)
         {
            container.Register<Servicio>().AsSingleton();
         }
     }
}