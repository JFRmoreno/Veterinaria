namespace Veterinaria.Modelos;

public class Address_Supplier
{
    public int Id {get;set;}
    public string Direccion {get;set;}
    public int Master_supplierId {get;set;}
    public virtual Master_supplier Master_supplier {get;set;}
}