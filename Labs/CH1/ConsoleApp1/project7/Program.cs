Dictionary<string, string> contacts = new();
bool exit = false;

contacts.Add("Brody", "309-643-4138");
contacts.Add("Bubka", "309-142-2755");
contacts.Add("Becky", "309-472-9528");
contacts.Add("Andrew", "309-232-2311");

do
{
    Console.WriteLine("1. Add Contact \n2. View Contact\n3. Update Contact\n4. Delete Contact\n5. List All Contacts\n6. Exit");
    Console.Write("Enter Choice: ");
    string? choice = Console.ReadLine();
    if (choice.Equals("6"))
    {
        exit = true;
    }
    else if (choice.Equals("1"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        contacts.Add(name, phoneNumber);
    }
    else if (choice.Equals("2"))
    {
        Console.Write("Search Name: ");
        string name = Console.ReadLine();
        if (contacts.ContainsKey(name))
        {
            Console.WriteLine($"\nName: {name} \n Phone Number: {contacts[name]}");
        }
        else
        {
            Console.WriteLine("Contact Not found");
        }
    }
    else if (choice.Equals("3"))
    {
        Console.Write("Search Name to edit: ");
        string name = Console.ReadLine();
        if (contacts.ContainsKey(name))
        {
            Console.Write("Enter New Number: ");
            string phoneNumber = Console.ReadLine();
            contacts[name] = phoneNumber;
        }
        else
        {
            Console.WriteLine("Contact Not found");
        }
    }
    else if (choice.Equals("4"))
    {
        Console.Write("Search Name to Delete: ");
        string name = Console.ReadLine();
        if (contacts.ContainsKey(name))
        { 
            contacts.Remove(name);
        }
        else
        {
            Console.WriteLine("Contact Not found");
        }
    }
    else if (choice.Equals("5"))
    {
        foreach (KeyValuePair<string, string> contact in contacts)
        {
            Console.WriteLine($"------------------\n Name: {contact.Key} \n Phone Number: {contact.Value}");
            Console.WriteLine("------------------");
        }
    }


} while (exit == false);