namespace Veterinaria.Modelos;

public class Trade_transaction
{
    public int Id {get;set;}
    public int Payment_MethodId {get;set;}
    public virtual Payment_Method Payment_Method {get;set;}
    public virtual ICollection<Purchase_order> Purchase_Orders{get;set;}
}