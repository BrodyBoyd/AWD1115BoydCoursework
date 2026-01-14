using System.Linq;
using System.Runtime.InteropServices;

int? balance = 0;
int winnings = 0;
bool playing = true;



List<string> baseDeck = new List<string>
{
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
};

List<string> changingDeck = new List<string>
{
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
    "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
};

Console.WriteLine("Rules:");
Console.WriteLine("Get to 21 without going over");
Console.WriteLine("No counting cards ;)");
Console.WriteLine("Once a card is used it can't be used again until the deck is shuffled");
Console.WriteLine("Win pays double, blackjack pays 3x");
Console.WriteLine("J, Q, and K will show as a 10");
Console.WriteLine("Doubling down acts as a hit and also doubles your bet");
Console.WriteLine("Doubling down also ends your turn");
Console.WriteLine("If dealer has an Ace it will alwasy be 11");
Console.WriteLine("If dealer has less than 15 dealer will draw another card");
Console.WriteLine("and as always gamble responsibly!");
Console.WriteLine("------------------\n\n");

do
{
    if (changingDeck.Count < 10)
    {
        changingDeck = baseDeck;
        Console.WriteLine("(Deck Shuffled) \n");
    }
    List<int> myHand = new List<int> { };
    List<int> dealersHand = new List<int> { };
    int bet = 0;
    int CardsUntilShuffle = changingDeck.Count - 9;
    Console.WriteLine($"{changingDeck.Count} cards remaining, {CardsUntilShuffle} cards until shuffle\n");
    Console.WriteLine($"Welcome to the Blackjack Table!");
    Console.WriteLine($"Your balance is {balance}. Would you like to add more?");

    while (true)
    {
        Console.Write("y/n or type q to quit: ");
        string questionAnswer = Console.ReadLine();
        if (questionAnswer != null && questionAnswer == "y")
        {
            Console.Write("How much would you like to deposit: ");
            int addToBalance = Convert.ToInt32(Console.ReadLine());
            balance += addToBalance;
            Console.WriteLine($"\nYour balance: {balance.Value}");
            break;
        }
        else if (questionAnswer != null && questionAnswer == "n")
        {
            Console.WriteLine($"You will continue with a balance of {balance}");
            break;
        }
        else if (questionAnswer != null && questionAnswer == "q")
        {
            Console.WriteLine($"Thank you for playing!");
            Console.WriteLine($"Your total winnings this session were ${winnings}");
            Environment.Exit(0);

        }
        else
        {
            Console.WriteLine("Invalid Answer");
        }
    }

    int placedBet = 0;
    bool validBet = false;

    while (!validBet)
    {
        Console.Write("Enter your bet: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out placedBet))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }
        if (placedBet > balance)
        {
            Console.WriteLine($"Invalid bet. You only have {balance}.");
            continue;
        }

        if (placedBet <= 0)
        {
            Console.WriteLine("Bet must be greater than zero.");
            continue;
        }
        placedBet = Convert.ToInt32(input);

        validBet = true;
    }

    bet = placedBet;
    balance -= bet;
    Console.WriteLine($"Bet accepted: {bet}. New balance: {balance}");


    Console.WriteLine($"Your bet is {bet}.  Good luck");
    Console.WriteLine("------------------\n\n");
    for (int i = 0; i < 2; i++)
    {

        Random rng = new Random();

        int index = rng.Next(changingDeck.Count);
        string value = changingDeck[index];
        if (value == "J" || value == "Q" || value == "K")
        {
            myHand.Add(10);
        }
        else if (value == "A")
        {
            bool validAceValue = false;
            int aceValue;

            while (!validAceValue)
            {
                Console.Write("You got an Ace! Should it be 1 or 11? ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out aceValue))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 11.");
                    continue;
                }
                if (aceValue != 1 && aceValue != 11)
                {
                    Console.WriteLine("Ace can only be 1 or 11.");
                    continue;
                }
                myHand.Add(aceValue);
                validAceValue = true;
            }
        }
        else
        {
            myHand.Add(Convert.ToInt32(value));
        }
        changingDeck.RemoveAt(index);

        int dealerIndex = rng.Next(changingDeck.Count);
        string dealerValue = changingDeck[dealerIndex];
        if (dealerValue == "J" || dealerValue == "Q" || dealerValue == "K")
        {
            dealersHand.Add(10);
        }
        else if (dealerValue == "A")
        {
            dealersHand.Add(11);
        }
        else
        {
            dealersHand.Add(Convert.ToInt32(dealerValue));
        }
        changingDeck.RemoveAt(dealerIndex);
    }

    if (dealersHand.Sum() < 15)
    {
        Random rng = new Random();
        int dealerIndex = rng.Next(changingDeck.Count);
        string dealerValue = changingDeck[dealerIndex];
        if (dealerValue == "J" || dealerValue == "Q" || dealerValue == "K")
        {
            dealersHand.Add(10);
        }
        else if (dealerValue == "A")
        {
            dealersHand.Add(11);
        }
        else
        {
            dealersHand.Add(Convert.ToInt32(dealerValue));
        }
        changingDeck.RemoveAt(dealerIndex);

    }

    
    while (true)
    {
        Console.WriteLine($"Your cards are: ");
        for (int i = 0; i < myHand.Count; i++)
        {
            Console.Write($"{myHand[i]}, ");
        }
        Console.WriteLine($"\nYour hand sum is {myHand.Sum()}\n");
        Console.WriteLine($"The dealer has a {dealersHand[0]}");
        Console.WriteLine($"\n What is your next move?");
        Console.WriteLine($"Hit(h) | Stand(s) | Double down(d)");
        string playChoice = Console.ReadLine();
        if (playChoice == "h")
        {
            Random rng = new Random();

            int index = rng.Next(changingDeck.Count);
            string value = changingDeck[index];
            if (value == "J" || value == "Q" || value == "K")
            {
                myHand.Add(10);
            }
            else if (value == "A")
            {
                bool validAceValue = false;
                int aceValue;

                while (!validAceValue)
                {
                    Console.Write("You got an Ace! Should it be 1 or 11? ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out aceValue))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 or 11.");
                        continue;
                    }
                    if (aceValue != 1 && aceValue != 11)
                    {
                        Console.WriteLine("Ace can only be 1 or 11.");
                        continue;
                    }
                    myHand.Add(aceValue);
                    validAceValue = true;
                }
            }
            else
            {
                myHand.Add(Convert.ToInt32(value));
            }
            changingDeck.RemoveAt(index);
            if (myHand.Sum() > 21)
            {
                Console.WriteLine($"You hit and got a {myHand[myHand.Count - 1]}");
                Console.WriteLine($"Your total is now {myHand.Sum()} which is over 21");
                Console.WriteLine("You lost! :(\n\n");
                winnings -= bet;
                break;
            }
        }
        else if (playChoice == "s")
        {
            Console.WriteLine($"Your hand totaled {myHand.Sum()}");
            Console.WriteLine($"The dealers hand totaled {dealersHand.Sum()}");
            int playerTotal = myHand.Sum();
            int dealerTotal = dealersHand.Sum();

            if ((playerTotal == 21 && dealerTotal < 21) || (playerTotal == 21 && dealerTotal > 21) && (myHand.Count == 2))
            {
                Console.WriteLine("Blackjack! You Win!!!! Your money will be deposited into your balance");
                balance += bet * 3;
                winnings += bet * 3;
                Console.WriteLine($"New balance: ${balance}\n\n");
            }
            else if ((playerTotal <= 21 && playerTotal > dealerTotal) || (playerTotal <= 21 && dealerTotal > 21))
            {
                Console.WriteLine("You Win!!!! Your money will be deposited into your balance");
                balance += bet * 2;
                winnings += bet * 2;
                Console.WriteLine($"New balance: ${balance}\n\n");
            }
            else if (playerTotal > 21)
            {
                Console.WriteLine("You lost! :(\n\n");
                winnings -= bet;
            }
            else if (playerTotal == dealerTotal)
            {
                Console.WriteLine("You matched the dealer, you get your bet back\n\n");
                balance += bet;
            }
            else if (dealerTotal <= 21 && playerTotal < dealerTotal)
            {
                Console.WriteLine("You lost! :(\n\n");
                winnings -= bet;
            }
            
            break;
        }
        else if (playChoice == "d")
        {
            int doubleBet = bet * 2;
            if (bet > balance)
            {
                Console.WriteLine("Unable to double bet, balance too low");
                Console.WriteLine("This turn will act as a hit then stand");

                Random rng = new Random();

                int index = rng.Next(changingDeck.Count);
                string value = changingDeck[index];
                if (value == "J" || value == "Q" || value == "K")
                {
                    myHand.Add(10);
                }
                else if (value == "A")
                {
                    bool validAceValue = false;
                    int aceValue;

                    while (!validAceValue)
                    {
                        Console.Write("You got an Ace! Should it be 1 or 11? ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out aceValue))
                        {
                            Console.WriteLine("Invalid input. Please enter 1 or 11.");
                            continue;
                        }
                        if (aceValue != 1 && aceValue != 11)
                        {
                            Console.WriteLine("Ace can only be 1 or 11.");
                            continue;
                        }
                        myHand.Add(aceValue);
                        validAceValue = true;
                    }
                }
                else
                {
                    myHand.Add(Convert.ToInt32(value));
                }
                changingDeck.RemoveAt(index);

                Console.WriteLine($"Your hand totaled {myHand.Sum()}");
                Console.WriteLine($"The dealers hand totaled {dealersHand.Sum()}");
                int playerTotal = myHand.Sum();
                int dealerTotal = dealersHand.Sum();

                if ((playerTotal < 21 && playerTotal > dealerTotal) || (playerTotal < 21 && dealerTotal > 21))
                {
                    Console.WriteLine("You Win!!!! Your money will be deposited into your balance");
                    balance += bet * 2;
                    winnings += bet * 2;
                    Console.WriteLine($"New balance: ${balance}\n\n");
                }
                else if (playerTotal > 21)
                {
                    Console.WriteLine("You lost! :(\n\n");
                    winnings -= bet;
                }
                else if (playerTotal == dealerTotal)
                {
                    Console.WriteLine("You matched the dealer, you get your bet back\n\n");
                    balance += bet;
                }
                else if (dealerTotal <= 21 && playerTotal < dealerTotal)
                {
                    Console.WriteLine("You lost! :(\n\n");
                    winnings -= bet;
                }
                
                break;

            }
            else
            {
                balance -= bet;
                Random rng = new Random();

                int index = rng.Next(changingDeck.Count);
                string value = changingDeck[index];
                if (value == "J" || value == "Q" || value == "K")
                {
                    myHand.Add(10);
                }
                else if (value == "A")
                {
                    bool validAceValue = false;
                    int aceValue;

                    while (!validAceValue)
                    {
                        Console.Write("You got an Ace! Should it be 1 or 11? ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out aceValue))
                        {
                            Console.WriteLine("Invalid input. Please enter 1 or 11.");
                            continue;
                        }
                        if (aceValue != 1 && aceValue != 11)
                        {
                            Console.WriteLine("Ace can only be 1 or 11.");
                            continue;
                        }
                        myHand.Add(aceValue);
                        validAceValue = true;
                    }
                }
                else
                {
                    myHand.Add(Convert.ToInt32(value));
                }
                changingDeck.RemoveAt(index);

                Console.WriteLine($"Your hand totaled {myHand.Sum()}");
                Console.WriteLine($"The dealers hand totaled {dealersHand.Sum()}");
                int playerTotal = myHand.Sum();
                int dealerTotal = dealersHand.Sum();

                if ((playerTotal <= 21 && playerTotal > dealerTotal) || (playerTotal <= 21 && dealerTotal > 21))
                {
                    Console.WriteLine("You Win!!!! Your money will be deposited into your balance");
                    balance += doubleBet * 2;
                    winnings += doubleBet * 2;
                    Console.WriteLine($"New balance: ${balance}\n\n");
                }
                else if (playerTotal > 21)
                {
                    Console.WriteLine("You lost! :(\n\n");
                    winnings -= doubleBet;
                }
                else if (playerTotal == dealerTotal)
                {
                    Console.WriteLine("You matched the dealer, you get your bet back\n\n");
                    balance += doubleBet;
                }
                else if (dealerTotal <= 21 && playerTotal < dealerTotal)
                {
                    Console.WriteLine("You lost! :(\n\n");
                    winnings -= doubleBet;
                }
                
                break;
            }
        }
    }
}
while (playing == true);
