using Microsoft.Data.SqlClient;
using Dapper;

public class BD
{
    private string _connectionString;
   
    public BD()
    {
        _connectionString = @"Server=localhost; DataBase = Album De Figuritas; Integrated Security=True; TrustServerCertificate=True;";
    }

    public List<Figurita> figusTotal()
    {
        List<Figurita> figurita = new List<Figurita>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM FiguritaUsuario";
            figurita = connection.Query<Figurita>(query).ToList();
        }
        return figurita;
    }

        public List<Seleccion> seleccion()
    {
        List<Seleccion> seleccion = new List<Seleccion>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM SELECCION";
            seleccion = connection.Query<Seleccion>(query).ToList();
        }
        return seleccion;
    }

        public List<Jugador> jugadores()
    {
        List<Jugador> jugadores = new List<Jugador>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM JUGADOR";
            jugadores = connection.Query<Jugador>(query).ToList();
        }
        return jugadores;
    }
     public Figurita SumarCantFigu()
    {
        Figurita figurita = new Figurita();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE FiguritaUsuario SET CANTIDAD + CANTIDAD = 1";
            figurita = connection.Query<Figurita>(query);
        }
            return figurita;
    }

}