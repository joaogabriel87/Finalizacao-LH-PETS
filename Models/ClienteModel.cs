using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LH_PETS.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Paciente { get; set; }
    }

     public class ForncedorModel
    {
        public int Id { get; set; }
        public string Fornecedora  { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
    }
}