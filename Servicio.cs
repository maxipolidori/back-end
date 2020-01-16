using System;
using System.Collections.Generic;

namespace Backend
{
    public class Servicio
    {
        private List<Cliente> listaClientes;
        private int nextIdCliente;
        
        public Servicio()
        {
            listaClientes = new List<Cliente>();
            nextIdCliente = 1;
        }

        public Cliente Create(Cliente c)
        {
            c.Id = nextIdCliente;
            listaClientes.Add(c);
            nextIdCliente++;
            return c;
        }

        public List<Cliente> Read()
        {
            return listaClientes;
        }

        public Cliente Read(int id)
        {
            Cliente c = listaClientes.Find(x => x.Id == id);
            return c;
        }

        public int Update(int id, Cliente c)
        {
            int index = listaClientes.FindIndex(t => t.Id == id);
            if(index >= 0)
                listaClientes[index] =  c;
            return index;
        }

        public int Delete(int id)
        {
            int index = listaClientes.FindIndex(t => t.Id == id);
            if(index >= 0)
                listaClientes.RemoveAt(index);
            return index;
        }
    }
}
