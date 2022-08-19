using Pottencial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Domain.Interfaces.Services
{
    public interface IVendaService 
    {
        Venda Post(Venda obj);  
    }
}
