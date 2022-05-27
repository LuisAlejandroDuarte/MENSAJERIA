using Mensajeria.DTOs;
using Mensajeria.DTOs.Usuarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.RepositoryEFCore.DataContext;
using System.Linq.Dynamic.Core;

namespace Mensajeria.RepositoryEFCore.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MensajeriaContext Context;

        public UsuarioRepository(MensajeriaContext context)
        {
            this.Context = context;
        }

        public void CrearUsuarios(Usuario usuario)
        {
            var user = Context.Usuarios.FirstOrDefault(x => x.User == usuario.User && x.EmpresaId == usuario.EmpresaId);
            if (user != null)
            {
                throw new Exception("Ese usuario ya existe");
            }

            Context.Add(usuario);
            
        }

        public void ActualizarUsuario(ActualizarUsuarioDTO usuario)
        {
            var userCurrent = Context.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            

            if (userCurrent == null)
            {
                throw new Exception("El usuario con Id " + usuario.Id + "No existe");
            }

            if (usuario.User != userCurrent.User)
            {
                var userValidate = Context.Usuarios.FirstOrDefault(x => x.User == usuario.User && x.EmpresaId == usuario.Id);

                if (userValidate != null)
                {
                    throw new Exception("El usuario " + usuario.User + " ya existe");
                }
            }
            userCurrent.Id = usuario.Id;
            userCurrent.Nombre = usuario.Nombre;
            userCurrent.Apellido = usuario.Apellido;
            userCurrent.Direccion = usuario.Direccion;
            userCurrent.Telefono = usuario.Telefono;
            userCurrent.Estado = usuario.Estado;
            userCurrent.User=usuario.User;
            userCurrent.EmpresaId = usuario.EmpresaId;            

            Context.ChangeTracker.Clear();
            Context.Update(userCurrent);
        }



        public IEnumerable<Usuario> GetAll()
        {
            return Context.Usuarios;
        }

        public UsuarioDTO Login(LoginDTO login)
        {
            var users= Context.Usuarios?.FirstOrDefault(u=>u.User==login.UserName && u.EmpresaId==login.EmpresaId);

            if (users!=null)
                return new UsuarioDTO()
                {
                    Id = users.Id,
                    User = users.User,
                    Nombre = users.Nombre,
                    Apellido = users.Apellido,
                    Direccion = users.Direccion,
                    Telefono = users.Telefono,
                    EmpresaId = users.EmpresaId,
                    Rol=users.Rol,
                    Estado=users.Estado,
                    Password=users.Password
                };          
            return null;
        }

         public UsuarioDTO GetUser(long Id)
         {
            var usuario = Context.Usuarios.FirstOrDefault(u => u.Id==Id);
            UsuarioDTO user=null;
            if (usuario != null)
            {
                user = new UsuarioDTO()
                {
                    Id = usuario.Id,
                    User=usuario.User,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Direccion = usuario.Direccion,
                    Telefono = usuario.Telefono,
                    Rol = usuario.Rol,
                    Estado=usuario.Estado,
                    EmpresaId = usuario.EmpresaId,
                    Password=usuario.Password
                };
            }
            
            return user;
         }

        public void ChangePassword(UsuarioDTO usuario)
        {
            var userCurrent = Context.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            if (userCurrent==null)
            {
                throw new Exception("El usuario no existe");
            }

            if (userCurrent.Password!=null)
            {
                userCurrent.Password = usuario.Password;
            }

            Context.Update(userCurrent);
        }

        public ResultDataTable GetAllUsuarios(Paginator paginator)
        {
            int totalReg = 0;
            int filterReg = 0;

            var usuarios = Context.Usuarios.Where(x => x.EmpresaId == paginator.idEmpresa);
            totalReg = usuarios.Count();
            filterReg = usuarios.Count();
            if (!string.IsNullOrWhiteSpace(paginator.searchby))
            {
                var filterBy = usuarios.Where(x =>
                               x.User.Contains(paginator.searchby) ||
                               x.Rol.Contains(paginator.searchby) ||
                               x.Nombre.Contains(paginator.searchby) ||
                               x.Apellido.Contains(paginator.searchby) ||
                               x.Direccion.Contains(paginator.searchby) ||
                               x.Telefono.Contains(paginator.searchby));
                usuarios = filterBy;
                filterReg = filterBy.Count();
                totalReg = usuarios.Count();
            }

            if (!string.IsNullOrWhiteSpace(paginator.sortColumn.ToString()) && !string.IsNullOrWhiteSpace(paginator.sortDirection))
            {              
                usuarios = usuarios.OrderBy(paginator.sortColumn.ToString() + " " + paginator.sortDirection);

            }

            usuarios = usuarios.Skip(paginator.start).Take(paginator.length);

            var modelo = new List<UsuarioDTO>();
            foreach (var item in usuarios)
            {
                modelo.Add(new UsuarioDTO()
                {
                    Id = item.Id,
                    EmpresaId = item.EmpresaId,
                    User = item.User,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Direccion = item.Direccion,
                    Telefono = item.Telefono,
                    Estado = item.Estado,
                    Rol=item.Rol,
                    //Para mostrar en tabla DataTable.NET
                    Bloqueado = (item.Estado == true) ? "Si" : "No",
                    Edit = ""
                });
            }

            return new ResultDataTable()
            {
                data = modelo,
                draw = paginator.draw.Value,
                recordsFiltered = filterReg,
                recordsTotal = totalReg,
            };

        }
            
    }
}
