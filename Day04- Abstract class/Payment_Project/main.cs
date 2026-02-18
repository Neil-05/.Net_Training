namespace Payment{
    class Program {
        static void Main(string[] args) {
            Payment upiPayment = new UPIPayment(1500.00m, "Neil@neyupi");
            upiPayment.Pay();
            upiPayment.PrintReceipt();
        }
    }
}