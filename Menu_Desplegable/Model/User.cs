using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Desplegable.Model
{
    [Table("user")]

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100), Unique]
        public string Celular { get; set; }

        [MaxLength(100)]
        public string Direccion { get; set; }

        [MaxLength(100), Unique]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }

    public class UserMascota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Raza { get; set; }

        [MaxLength(100)]
        public string Peso { get; set; }

        [MaxLength(100)]
        public string Especie { get; set; }

        [MaxLength(100)]
        public int Edad { get; set; }

    }
}
