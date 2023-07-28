namespace Veterinaria.Modelos;

public class Pets_customer
{
    public int Id {get;set;}
    public string Nombre_Mascota {get;set;}
    public int Edad {get;set;}
    public int Master_customerId {get;set;}

    public virtual Master_customer Master_customer {get;set;}
}