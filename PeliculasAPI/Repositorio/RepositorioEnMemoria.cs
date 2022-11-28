using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorio
{
    public class RepositorioEnMemoria // trabajara con data en memoria
    {
        // listado privado de generos
        private List<Genero> _generos;

        public RepositorioEnMemoria(ILogger<RepositorioEnMemoria> logger)
        {
            // inicializar el listado con datos de prueba
            _generos = new List<Genero>()
            {
                new Genero(){Id = 1, Nombre = "Comedia"},
                new Genero(){Id = 2, Nombre = "Accion"},

            };

            _guid = Guid.NewGuid(); // 12344566-ASDASD-DASD23443-SDFSDVCXXAAW
        }

        public Guid _guid;

        // Metodo para devolver todos los generos
        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        public async Task<Genero> ObtenerPorId(int Id)
        {
            await Task.Delay(1);
                                // traer el primer genero que coincida con el id enviado
            return _generos.FirstOrDefault(x => x.Id == Id);
        }

        public Guid ObtenerGuid()
        {
            return _guid;
        }

        public void CrearGenero(Genero genero)
        {
            genero.Id = _generos.Count() + 1;
            _generos.Add(genero);
        }
    }
}
