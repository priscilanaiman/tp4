using Microsoft.Data.SqlClient;
using Dapper;
public class Jugador
{
    public int Id;
    public string Nombre;
    public string Posicion;
    public int NumeroCamiseta;
    public Seleccion Seleccion;

}