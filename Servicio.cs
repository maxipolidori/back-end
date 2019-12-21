using System;
using System.Collections.Generic;

namespace Backend
{
    public class Servicio
    {
        private List<Tuple<int, Cliente>> listaClientes;
        private int nextIdCliente;
        
        public Servicio()
        {
            listaClientes = new List<Tuple<int, Cliente>>();
            nextIdCliente = 1;
        }

        public Cliente Create(Cliente c)
        {
            Cliente resp = c;
            resp.Id = nextIdCliente;
            Tuple<int, Cliente> t = new Tuple<int, Cliente> (nextIdCliente, resp);
            listaClientes.Add(t);
            nextIdCliente++;
            return resp;
        }

        public List<Cliente> Read()
        {
            List<Cliente> list = new List<Cliente>();
            foreach(Tuple<int, Cliente> t in listaClientes)
            {
                Cliente c = t.Item2;
                list.Add(c);
            }
            return list;
        }

        public Cliente Read(int id)
        {
            Tuple<int, Cliente> t = listaClientes.Find(x => x.Item1 == id);
            if(t != null)
                return t.Item2;
            else return null;
        }

        public int Update(int id, Cliente c)
        {
            int index = listaClientes.FindIndex(t => t.Item1 == id);
            if(index >= 0)
                listaClientes[index] =  new Tuple<int, Cliente>(id, c);
            return index;
        }

        public int Delete(int id)
        {
            int index = listaClientes.FindIndex(t => t.Item1 == id);
            if(index >= 0)
                listaClientes.RemoveAt(index);
            return index;
        }
    }
}
