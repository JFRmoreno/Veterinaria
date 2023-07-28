namespace Veterinaria.Modelos;

public class Payment_Method
{
    public int Id {get;set;}
    public string Metodo_tarjeta {get;set;}
    public string Efectivo {get;set;}
    public virtual Trade_transaction Trade_transaction {get;set;}
}
