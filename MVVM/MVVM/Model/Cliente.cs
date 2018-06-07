using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //public byte[] Foto { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
