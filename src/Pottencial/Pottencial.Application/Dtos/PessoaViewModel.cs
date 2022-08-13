using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Application.Dtos
{
    public class PessoaViewModel : BaseViewModel
    {
        public int Idade { get; set; }
        public string NomeCompleto { get; set; }
    }
}
