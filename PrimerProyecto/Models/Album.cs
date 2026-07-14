using Microsoft.Data.SqlClient;
using Dapper;
public class Album
{

    public BD bd = new BD();

    public List<Figurita> coleccion = new List<Figurita>();
    public List<Figurita> repetidas = new List<Figurita>();
    public List<Figurita> pegadas = new List<Figurita>();
    public List<Figurita> total = new List<Figurita>();
    public List<Seleccion> seleccion = new List<Seleccion>();
    public List<Jugador> jugadores = new List<Jugador>();
    public List<Figurita> faltantes = new List<Figurita>();

    public Album()
    {
        foreach(Figurita figu in coleccion)
        {
            if (figu.Cantidad > 2)
            {
                this.repetidas.Add(figu);
            }
        }

        foreach(Figurita figu in coleccion)
        {
            if (figu.Cantidad > 1)
            {
                this.pegadas.Add(figu);
            }
        }
        this.total = bd.figusTotal();
        this.seleccion = bd.seleccion();
        this.jugadores = bd.jugadores();
    }
    public List<Figurita> verColeccion()
    {
        return coleccion;
    }
    public List<Figurita> verRepetidas()
    {
        return repetidas;
    }
    public List<Figurita> verPegadas()
    {
        return pegadas;
    }
    public List<Figurita> verFaltantes()
    {
        foreach(Figurita figu in total)
        {
            if (!coleccion.Contains(figu))
            {
                faltantes.Add(figu);
            }
        }
        return faltantes;
    }
    public List<Figurita> devolverListaRandoms()
    {
        Random random = new Random();
        return this.total.Distinct().OrderBy(x => random.Next()).Take(5).ToList();
    }   
}