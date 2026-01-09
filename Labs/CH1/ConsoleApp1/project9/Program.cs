using project9;

Corner corner = new();
Leaf leaf = new();
Page page = new();
Pancake pancake = new();

List<ITurnable> turns = new List<ITurnable>{ corner, leaf, page, pancake };
static void Turning(List<ITurnable> t)
{
    foreach (ITurnable turn in t)
    {
        Console.WriteLine(turn.Turn());
    }
}

Turning(turns);