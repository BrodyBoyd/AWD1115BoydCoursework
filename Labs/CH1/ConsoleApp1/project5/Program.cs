string ccNumber;

do
{
    Console.WriteLine("Enter a Credit Card Number");
    ccNumber = Console.ReadLine();
} while (String.IsNullOrEmpty(ccNumber));

string maskedNum = String.Empty;

for  (int i = 0; i < ccNumber.Length; i++)
{
     if (ccNumber[i] == '-' || Char.IsWhiteSpace(ccNumber[i]) || i >= ccNumber.Length - 4)
    {
        maskedNum += ccNumber[i];
    }
    else
    {
        maskedNum += 'X';
    }
}

Console.WriteLine(maskedNum);