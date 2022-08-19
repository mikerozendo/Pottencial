﻿using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;

namespace Pottencial.Infraestructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private List<Vendedor> vendedores { get; set; } = new();

        public IEnumerable<Vendedor> Get()
        {
            return vendedores;
        }

        public Vendedor Post(Vendedor vendedor)
        {
            vendedores.Add(vendedor);
            return vendedores.FirstOrDefault(vendedor);
        }

        public int ObterQuantiadeVendedores()
        {
            return vendedores.Count;
        }

        public void Remove(Vendedor vendedor)
        {
            vendedores.Remove(vendedor);
        }
    }
}