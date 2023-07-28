namespace Veterinaria.Modelos;

public class Purchase_order
{
    public int Id {get;set;}
    public int Cantidad {get;set;}
    public int Master_productId {get;set;}
    public int Address_CustomerId {get;set;}
    public int Trade_transactionId {get;set;}
    public virtual Master_product Master_product {get;set;}
    public virtual Address_Customer Address_Customer {get;set;}
    public virtual Trade_transaction Trade_transaction {get;set;}
}