using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class PanelaService
    {
        private readonly ConnectionManager _conexion;
        private readonly PanelaRepository _repositorio;
        public PanelaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new PanelaRepository (_conexion);
        }
        public GuardarPanelaResponse Guardar(Panela  panela)
        {
            try
            {
                 
                _conexion.Open();
                _repositorio.Guardar( panela);
                _conexion.Close();
                return new GuardarPanelaResponse(panela);
            }
            catch (Exception e)
            {
                return new GuardarPanelaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Panela> ConsultarTodos()
        {
            _conexion.Open();
            List<Panela>  panelas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return  panelas;
        }
        public Panela BuscarPorIdentificacion(string idregistro)
        {
            _conexion.Open();
            Panela panela = _repositorio.BuscarPorIdentificacion(idregistro);
            _conexion.Close();
            return panela;
        }

        public string Eliminar(string idregistro)
        {
            try
            {
                _conexion.Open();
                var panela = _repositorio.BuscarPorIdentificacion(idregistro);
                if (panela != null)
                {
                    _repositorio.Eliminar(panela);
                    _conexion.Close();
                    return ($"El registro {panela.Idregistro} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {idregistro} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }



        public class GuardarPanelaResponse 
    {
        public GuardarPanelaResponse(Panela panela)
        {
            Error = false;
            Panela = panela;
        }
        public GuardarPanelaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Panela Panela { get; set; }
    }
}
}

