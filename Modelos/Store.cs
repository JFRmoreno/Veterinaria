namespace Veterinaria.Modelos;

public class Store
{
    public int Id {get;set;}
    public string Direccion {get;set;}
    public string Nombre_Punto_venta {get;set;}

    public virtual ICollection<Doctors> Doctors {get;set;}
    public virtual ICollection<Master_product> Master_product {get;set;}
}