Predicate<int>  isEven = number => number %2==0; // Predicate to check if a number is even cause it returns a bool
bool result= isEven(4);
Console.WriteLine(result);


Action<string> logger = message =>
{
    Console.WriteLine($"Log: {message} at {DateTime.Now}");
};
// Using the Action to log different messages based on the time of day


logger("Learning Actions in C#");

if(DateTime.Now.Hour < 12)
{
    logger("Good Morning!");
}
else if(DateTime.Now.Hour < 18)
{
    logger("Good Afternoon!");
}
else
{
    logger("Good Evening!");
}



Func<int,int,string> multiplyr=(x,y) =>
{
    return $"The product of {x} and {y} is {x*y}";
};

string resultfunc= multiplyr(5,6);
Console.WriteLine(resultfunc);
