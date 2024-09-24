 using SQLite;
using System;

namespace Menu_Desplegable.Model
{
    [Table("citas")]
    public class Cita
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int MascotaId { get; set; }
        public int VeterinarioId { get; set; }  // Nuevo campo

        public DateTime Fecha { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }
        public string veterinarioDES { get; set; }
        public string EspecialidadVeterinaria { get; set; }
    }
}


