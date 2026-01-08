int[] testScores = new int[10];
int scoreNum = 0;
int best = 0;
int worst = 100;
int sum = 0;
do
{
    int enteredNum = 101;
    Console.WriteLine($"Enter a test score.    {scoreNum}/10 entered");
    int.TryParse(Console.ReadLine(), out enteredNum);

    if (enteredNum >= 0 && enteredNum <= 100)
    {
        testScores[scoreNum] = enteredNum;
        scoreNum++;
    }
    
} while (scoreNum < 10);

foreach (int i in testScores)
{
    best = int.Max(best, i);
    worst = int.Min(worst, i);
    sum += i;
}

Console.WriteLine($"Best: {best}\nWorst: {worst}\nSum: {sum}\nAverage: {sum / 10}");