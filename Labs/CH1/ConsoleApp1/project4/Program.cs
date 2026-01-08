Console.WriteLine("Enter the string you would like to reverse");
string name = Console.ReadLine();

for (int i = name.Length - 1; i >= 0; i--)
{
    Console.WriteLine(name[i]);
}