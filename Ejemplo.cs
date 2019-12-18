using System;
using System.Collections.Generic;
using System.IO;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Backend
{
    public class Ejemplo : Nancy.NancyModule
    {
        private static List<Tuple<int, Cliente>> listaClientes = new List<Tuple<int,Cliente>> ();
        private static int nextIdCliente = 1;
        public Ejemplo()
        {
            Post("/", args => 
            {
                Cliente c = this.Bind();
                listaClientes.Add(new Tuple<int, Cliente>(nextIdCliente, c));
                nextIdCliente++;
                return Response.AsJson("Cliente agregado");
            });

            Get("/clientes", args => 
            {
                List<Cliente> respuesta = new List<Cliente>();
                foreach(Tuple<int, Cliente> t in listaClientes)
                {
                    Cliente c = t.Item2;
                    respuesta.Add(c);
                }
                return JsonConvert.SerializeObject(respuesta);
            });

            Get("/clientes/{id:int}", args => 
            {
                int id = args.id;
                Tuple<int, Cliente> t = listaClientes.Find(x => x.Item1 == id);
                if(t != null)
                {
                    Cliente c = t.Item2;
                    return JsonConvert.SerializeObject(c);
                }
                else return Response.AsJson("Cliente inexistente");
                
            });

            Put("clientes/{id:int}", args => 
            {
                int id = args.id;
                int index = listaClientes.FindIndex(t => t.Item1 == id);
                if(index >= 0)
                {
                    Cliente newC = this.Bind();
                    listaClientes[index] =  new Tuple<int, Cliente>(id, newC);
                    return "Cliente editado";
                }
                else return "Cliente inexistente";
            });

            Delete("clientes/{id:int}", args => 
            {
                int id = args.id;
                int index = listaClientes.FindIndex(t => t.Item1 == id);
                if(index >= 0)
                {
                    listaClientes.RemoveAt(index);
                    return "Cliente eliminado";
                }
                else return "Cliente inexistente";
            });
        }
    }
}