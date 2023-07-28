namespace Veterinaria.Modelos;

public class Master_supplier
{
   public int Id {get;set;}
   public string Nombre_proveedor {get;set;}
   public int Master_productId {get;set;}
   public virtual Master_product Master_product {get;set;} 
   public virtual ICollection<Address_Supplier> Address_Supplier {get;set;}
}