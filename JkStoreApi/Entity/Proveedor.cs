﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proveedor:Usuario
    {
        public List<Producto> Productos { get; set; }
    }
}
