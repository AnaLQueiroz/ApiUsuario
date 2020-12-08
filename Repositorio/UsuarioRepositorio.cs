using System.Collections.Generic;
using System.Linq;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly UsuarioDbContext _contexto;

        public UsuarioRepositorio(UsuarioDbContext ct)
        {
            _contexto = ct;
        }


        public void Add(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuario Find(long id)
        {
           return _contexto.Usuarios.FirstOrDefault(use=> use.UsuarioId == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
           return _contexto.Usuarios.ToList();
        }

        public void Remove(long id)
        {
            var entidade = _contexto.Usuarios.First(use=>use.UsuarioId == id);
            _contexto.Usuarios.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
           _contexto.Usuarios.Update(usuario);
           _contexto.SaveChanges();
        }
    }
}