using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;

namespace Pottencial.Infraestructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private List<Vendedor> vendedores { get; set; } = new();

        public IEnumerable<Vendedor> Get(int id = 0)
        {
            if (id == 0) return vendedores;

            return vendedores.Where(x => x.Id == id);
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

        public Vendedor? ObterPorDocumento(Vendedor vendedor)
        {
            return vendedores.FirstOrDefault(x => x.CPF.Cpf == vendedor.CPF.Cpf);
        }

        public Vendedor Put(Vendedor obj)
        {
            return Post(obj);
        }
    }
}
