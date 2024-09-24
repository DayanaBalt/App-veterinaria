using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Desplegable.Model
{
    public class UserRepository
    {
        private SQLiteConnection con;

        private static UserRepository instancia;

        public static UserRepository Instancia
        {

            get
            {
                if (instancia == null)

                    throw new Exception("debe llamar al inicializador");

                return instancia;
            }
        }
        public static void Inicializador(string filename)
        {
            if (filename == null)

                throw new ArgumentNullException();

            if (instancia != null)

                instancia.con.Close();

            instancia = new UserRepository(filename);

        }

        private UserRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>();
            con.CreateTable<UserMascota>();
            con.CreateTable<Cita>();
            con.CreateTable<Veterinario>();
        }


        public string EstadoMensaje;

        public int AddNewUser(string name, string celular, string Direccion)
        {

            int result = 0;

            try
            {
                result = con.Insert(new User()

                {
                    Name = name,
                    Celular = celular,
                    Direccion = Direccion

                });

                EstadoMensaje = string.Format("cantidad de filas afectadas:{0} ", result);

            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;

            }
            return result;
        }

        public int AddNewUserM(string name, string raza, string peso, string especie, int edad)
        {
            int result = 0;
            try
            {
                result = con.Insert(new UserMascota
                {
                    Name = name,
                    Raza = raza,
                    Peso = peso,
                    Especie = especie,
                    Edad = edad
                });
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }



        public IEnumerable<User> GetAllUsers()
        {
            {
                try
                {
                    return con.Table<User>();

                }

                catch (Exception e)

                {
                    EstadoMensaje = e.Message;

                }
            }
            return Enumerable.Empty<User>();
        }

        public IEnumerable<UserMascota> GetAllUsersM()
        {
            try
            {
                return con.Table<UserMascota>().OrderBy(um=>um.Name);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<UserMascota>();
        }

        public int UpdateUser(User user)
        {
            int result = 0;
            try
            {
                result = con.Update(user);
                EstadoMensaje = string.Format("cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int UpdateUserM(UserMascota userMascota)
        {
            int result = 0;
            try
            {
                result = con.Update(userMascota);
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            try
            {
                result = con.Delete<User>(id);
                EstadoMensaje = string.Format("cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int DeleteUserM(int id)
        {
            int result = 0;
            try
            {
                result = con.Delete<UserMascota>(id);
                EstadoMensaje = string.Format("cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public User GetUser(string username, string password)
        {
            try
            {
                return con.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
                return null;
            }
        }

        public int RegisterUser(string name, string celular, string direccion, string username, string password)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User
                {
                    Name = name,
                    Celular = celular,
                    Direccion = direccion,
                    Username = username,
                    Password = password
                });

                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int AddNewCita(int userId, int mascotaId, int veterinarioId, DateTime fecha, string descripcion, string veterinarioDES, string EspecilidadV)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Cita
                {
                    UserId = userId,
                    MascotaId = mascotaId,
                    VeterinarioId = veterinarioId,  // Nuevo campo
                    Fecha = fecha,
                    Descripcion = descripcion,
                    veterinarioDES = veterinarioDES // nuevo campo


                });
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }


        public IEnumerable<Cita> GetAllCitas()
        {
            try
            {
                return con.Table<Cita>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
                return Enumerable.Empty<Cita>();
            }
        }

        public int UpdateCita(Cita cita)
        {
            int result = 0;
            try
            {
                result = con.Update(cita);
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }
        public int DeleteCita(int id)
        {
            int result = 0;
            try
            {
                result = con.Delete<Cita>(id);
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int AddNewVeterinario(string nombre, string apellido, string especialidad, string telefono, string descrip)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Veterinario
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Especialidad = especialidad,
                    Telefono = telefono,
                    descripcion = descrip
                });
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            try
            {
                return con.Table<Veterinario>().OrderBy(v=>v.Nombre);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Veterinario>();
        }

        public int UpdateVeterinario(Veterinario veterinario)
        {
            int result = 0;
            try
            {
                result = con.Update(veterinario);
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int DeleteVeterinario(int id)
        {
            int result = 0;
            try
            {
                result = con.Delete<Veterinario>(id);
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }
        public Veterinario GetVeterinarioById(int id)
        {
            var user = con.Table<Veterinario>().FirstOrDefault(u => u.VeterinarioID == id);
            return user;
        }


        // prueba del metodo de busqueda
        public List<Veterinario> GetVeterinarios()
        {
            return con.Table<Veterinario>().ToList();
        }

        public List<Veterinario> SearchVeterinariosByNamestr( string name)
        {
            return con.Table<Veterinario>()
                            .Where(v => v.Nombre.ToLower().Contains(name.ToLower()))
                            .ToList();
        }
        
        public List<UserMascota> GetMascota()
        {
            return con.Table<UserMascota>().ToList();
        }

        public List<UserMascota> SearchMascotaByNombre ( string mascota)
        {
            return con.Table<UserMascota>(). Where(m=> m.Name.ToLower().Contains(mascota.ToLower())).ToList();
            

        }
        public List<User> GetUsers()
        {
            return con.Table<User>().ToList();
        }
        public List<User> SearchClienteByNombre( string cliente )
        {
            return con.Table<User>().Where (c=>c.Name.ToLower().Contains(cliente.ToLower())).ToList ();
        }
        // metodo para hacer los llamados de las citas para la busqueda 
        public UserMascota GetUserMasc (int id)
        {
            return con.Table<UserMascota>().FirstOrDefault(c => c.Id == id);
        }
       






	}
}
