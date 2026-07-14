using Microsoft.Data.SqlClient;
using Dapper;
public class Sobre
{
    BD bd = new BD();
    Album album = new Album();
    public List<Figurita> sobre = new List<Figurita>();

    public void confirmarSobre()
    {
        foreach(Figurita figu in sobre)
        {
            if (!album.coleccion.Contains(figu))
            {
                album.coleccion.Add(figu);
            }
            figu = bd.SumarCantFigu;
        }
    }
    public List<Figurita> abrirSobre()
    {
        this.sobre = album.devolverListaRandoms();
        return sobre;
    }
}