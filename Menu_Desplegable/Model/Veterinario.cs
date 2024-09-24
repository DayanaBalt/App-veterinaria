using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SQLite;

namespace Menu_Desplegable.Model
{
    [Table("veterinarios")]
    public class Veterinario
    {
        [PrimaryKey, AutoIncrement]
        public int VeterinarioID { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Apellido { get; set; }

        [MaxLength(100)]
        public string Especialidad { get; set; }

        [MaxLength(100)]
        public string Telefono { get; set; }
        public string descripcion { get; set; }
    }
}

