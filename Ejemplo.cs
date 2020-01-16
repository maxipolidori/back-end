using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;

namespace Backend
{
    public class Ejemplo : Nancy.NancyModule
    {
        private Servicio servicio;

        public Ejemplo(Servicio s)
        {
            servicio = s;

            Post("/", args => 
            {
                Cliente c = this.Bind();
                Cliente resp = servicio.Create(c);
                return Response.AsJson(resp);
            });

            Get("/clientes", args => 
            {
                return Response.AsJson(servicio.Read());
            });

            Get("/clientes/{id:int}", args => 
            {
                Cliente c = servicio.Read(args.id);
                if(c != null)
                    return Response.AsJson(c);
                else return null;                
            });

            Put("clientes/{id:int}", args => 
            {
                int id = args.id;
                Cliente c = this.Bind();
                int resp = servicio.Update(id, c);
                if(resp >= 0)
                    return Response.AsJson(c);
                else return null;
            });

            Delete("clientes/{id:int}", args => 
            {
                int id = args.id;
                int resp = servicio.Delete(id);
                if(resp >= 0)
                    return HttpStatusCode.OK;
                else return HttpStatusCode.BadRequest;
            });
        }
    }
}
