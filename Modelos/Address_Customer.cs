namespace Veterinaria.Modelos;

public class Address_Customer
{
    public int Id {get;set;}
    public string Direccion {get;set;}
    public int Master_customerId {get;set;}

    public virtual  Master_customer Master_customer {get;set;}
    public virtual ICollection<Purchase_order> Purchase_order {get;set;}
}