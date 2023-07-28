namespace Veterinaria.Modelos;

public class Date
{
    public int Id {get;set;}
    public DateTime Fecha_cita {get;set;}
    public int DoctorsId {get;set;}
    public int Master_customerId {get;set;}

    public virtual Doctors Doctors {get;set;}
    public virtual Master_customer Master_customer {get;set;}
}