namespace Veterinaria.Modelos
{
    public class Master_customer
    {
        public int Id {get;set;}
        public string Email {get;set;}
        public string Contraseña {get;set;}
        public string Nombre {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}

        public virtual ICollection<Pets_customer> Pets_customer {get;set;}
        public virtual ICollection<Address_Customer> Address_Customer{get;set;}
        public virtual ICollection<Date> Date {get;set;}
    }
}