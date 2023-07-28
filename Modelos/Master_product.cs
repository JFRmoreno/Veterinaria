namespace Veterinaria.Modelos;

public class Master_product
{
    public int id {get;set;}
    public string Nombre_Producto {get;set;}
    public int Cantidad {get;set;}
    public string Marca {get;set;}
    public int StoreId {get;set;}

    public virtual Store Store {get;set;}

    public virtual ICollection<Purchase_order>Purchase_order {get;set;}
    public virtual ICollection<Master_supplier>Master_supplier {get;set;}
}