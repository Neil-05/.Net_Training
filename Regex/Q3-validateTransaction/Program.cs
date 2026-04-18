using System.Text.RegularExpressions;
public class TransactionValidator
{
    public static string validateTransaction(string record)
    {
        // Example validation logic - replace with actual validation rules
        if(string.IsNullOrEmpty(record)) return "Invalid record";
        string[] parts= record.Split('|');
        if(parts.Length!=5) return "Invalid record";
        string txn=parts[0];
        if(!Regex.IsMatch(txn, @"^TXN-\d{6}$")) return "Invalid record";
        string digits= txn.Substring(4);
        if(digits.StartsWith("0")) return "Invalid record";
        if(Regex.IsMatch(digits, @"(\d)\1{3}")) return "Invalid record";
        string date=parts[1];
        if(!Regex.IsMatch(date,@"^\d{4}-\d{2}-\d{2}$")) return "Invalid record";
        string[] dateparts= date.Split('-');
        int year=int.Parse(dateparts[0]);
        int month=int.Parse(dateparts[1]);
        int day=int.Parse(dateparts[2]);
        if(year<2000 || year> 2099) return "Invalid record";
        if(month<1 || month>12) return "Invalid record";
        int[] daysinmonth={31,(year%4==0)?29:28,31,30,31,30,31,31,30,31,30,31};
        if(day<1 || day>daysinmonth[month-1]) return "Invalid record";
        string[] currencyall={"USD", "EUR","INR", "GBP", "AUD", "CAD"};
        string currency=parts[2];
        if(!currencyall.Contains(currency)) return "Invalid record";

        string amount=parts[3];
        if(!Regex.IsMatch(amount, @"^(0|[1-9]\d*)(\.\d{1,2})?$")) return "Invalid record";

        if(!decimal.TryParse(amount,out decimal amt)) return "Invalid record";
        if(amt<0 || amt>999999.99m) return "Invalid record";

        string status=parts[4];
        string[] validstatus={"PENDING", "SUCCESS", "FAILED"};
        if(!validstatus.Contains(status)) return "Invalid record";

        return "Valid record";

    }
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Console.WriteLine(validateTransaction(input));
        }
    }
}