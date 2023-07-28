namespace Veterinaria.Modelos;

public class Doctors
{
    public int Id {get;set;}
    public string Nombre_Doctor {get;set;}
    public string Especialidad {get;set;}
    public int StoreId {get;set;}
    public virtual required Store Store {get;set;}
    public virtual ICollection<Date> Date {get;set;}
}