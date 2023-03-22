var random = new Random();

var numOfWeeks = random.Next(4, 11);
var numOfMeassurements = random.Next(3, 7);

Console.WriteLine($"{numOfWeeks} {numOfMeassurements}");

for(int i = 0; i < numOfWeeks; i++)
{
    for(int j = 0; j < numOfMeassurements; j++)
    {
        Console.Write($"{random.Next(-10,31)} ");
    }

    Console.WriteLine();
}