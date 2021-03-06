﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }
    }
}
