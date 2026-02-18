namespace Payment{
abstract class Payment {
    public decimal Amount{get;}
    protected Payment(decimal amount) {
        Amount = amount;
    }
    public void PrintReceipt() {
        System.Console.WriteLine($"Payment of {Amount:C} processed.");
    }

    public abstract void Pay();

    
}
class UPIPayment : Payment{
    public string UPIID{get;}
    public UPIPayment(decimal amount, string upiId) : base(amount){
        UPIID = upiId;
    
    }
    public override void Pay(){
        System.Console.WriteLine($"Processing UPI payment of {Amount:C} using UPI ID: {UPIID}");
    }
}
}