using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Sexo { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Senha { get; set; }
    }
}
