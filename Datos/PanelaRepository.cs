using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class PanelaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Panela> _panelas = new List<Panela>();
        public PanelaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Panela panela)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Panela (Idregistro,FechaIngreso,NumeroLote,NumeroLoteAgricola,Etapas,Cantidad,Responsable) 
                                        values (@Idregistro,@FechaIngreso,@NumeroLote,@NumeroLoteAgricola,@Etapas,@Cantidad,@Responsable)";
                command.Parameters.AddWithValue("@Idregistro", panela.Idregistro);
                command.Parameters.AddWithValue("@FechaIngreso", panela.FechaIngreso);
                command.Parameters.AddWithValue("@NumeroLote", panela.NumeroLote);
                command.Parameters.AddWithValue("@NumeroLoteAgricola", panela.NumeroLoteAgricola);
                command.Parameters.AddWithValue("@Etapas",panela.Etapas);
                command.Parameters.AddWithValue("@Cantidad",panela.Cantidad);
                command.Parameters.AddWithValue("@Responsable",panela.Responsable);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar( Panela panela)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Panela where Idregistro=@Idregistro";
                command.Parameters.AddWithValue("@Idregistro", panela.Idregistro);
                command.ExecuteNonQuery();
            }
        }
        public List<Panela> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Panela> panelas = new List<Panela>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Panela ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Panela panela = DataReaderMapToPerson(dataReader);
                        panelas.Add(panela);
                    }
                }
            }
            return panelas;
        }
        public Panela BuscarPorIdentificacion(string idregistro)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Panela where Idregistro=@Idregistro";
                command.Parameters.AddWithValue("@Idregistro", idregistro);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }


       
        private Panela DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Panela panela = new Panela();
            panela.Idregistro=(string)dataReader["Idregistro"];
            panela.FechaIngreso = (DateTime)dataReader["FechaIngreso"];
            panela.NumeroLote = (string)dataReader["NumeroLote"];
            panela.NumeroLoteAgricola = (string)dataReader["NumeroLoteAgricola"];
            panela.Etapas = (string)dataReader["Etapas"];
            panela.Cantidad = (string)dataReader["Cantidad"];
             panela.Responsable = (string)dataReader["Responsable"];
             
            return panela;
        }
        
    }
}
