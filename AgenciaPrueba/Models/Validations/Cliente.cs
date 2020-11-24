using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgenciaPrueba.Models
{
    [MetadataType(typeof(Cliente.MetaDdata))]
    public partial class Cliente
    {
        sealed class MetaDdata
        {
            [Required]
            public string Cedula;
            [Required]
            public string Nombre;
            [Required]
            public string Direccion;
            [Required]
            public Nullable<long> Telefono;

        }
    }
}