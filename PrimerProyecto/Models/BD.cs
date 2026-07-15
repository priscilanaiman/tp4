using Microsoft.Data.SqlClient;
using Dapper;

public class BD
{
    private string _connectionString;
   
    public BD()
    {
        //_connectionString = @"Server=localhost; DataBase = Album De Figuritas; Integrated Security=True; TrustServerCertificate=True;";
        _connectionString = @"Server=.\SQLEXPRESS;Database=Album De Figuritas;Integrated Security=True;TrustServerCertificate=True;";
    }
    public void reiniciarAlbum()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE FiguritaUsuario SET CANTIDAD = 0";
            connection.Execute(query);
        }
    }

    public List<Figurita> figuritas()
    {
        List<Figurita> figuritas = new List<Figurita>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM FiguritaUsuario ORDER BY ID";
            figuritas = connection.Query<Figurita>(query).ToList();
        }
        return figuritas;
    }

    public List<Figurita> sobre()
    {
        Random random = new Random();
        return figuritas().OrderBy(x => random.Next()).Take(5).ToList();
    }

    public void confirmarSobre(List<int> figuritaIds)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            foreach (int id in figuritaIds)
            {
                string query = "UPDATE FiguritaUsuario SET CANTIDAD = CANTIDAD + 1 WHERE ID = @Id";
                connection.Execute(query, new { Id = id });
            }
         }
    }

    // public List<Seleccion> seleccion()
    // {
    //     List<Seleccion> seleccion = new List<Seleccion>();
    //     using (SqlConnection connection = new SqlConnection(_connectionString))
    //     {
    //         string query = "SELECT * FROM SELECCION";
    //         seleccion = connection.Query<Seleccion>(query).ToList();
    //     }
    //     return seleccion;
    // }

    // public List<Jugador> jugadores()
    // {
    //     List<Jugador> jugadores = new List<Jugador>();
    //     using (SqlConnection connection = new SqlConnection(_connectionString))
    //     {
    //         string query = "SELECT * FROM JUGADOR";
    //         jugadores = connection.Query<Jugador>(query).ToList();
    //     }
    //     return jugadores;
    // }

    // public Figurita SumarCantFigu()
    // {
    //     Figurita figurita = new Figurita();
    //     using (SqlConnection connection = new SqlConnection(_connectionString))
    //     {
    //         string query = "UPDATE FiguritaUsuario SET CANTIDAD + CANTIDAD = 1";
    //         //figurita = connection.Query<Figurita>(query);
    //     }
    //         return figurita;
    // }

}