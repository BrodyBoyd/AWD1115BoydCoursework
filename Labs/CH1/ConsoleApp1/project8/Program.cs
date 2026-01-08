using project8;

Cart cart = new("1234");

cart.AddItem("Door", 14);
cart.AddItem("Car", 14000);
cart.AddItem("Gum", 1.3);
Console.WriteLine(cart);

cart.RemoveItem("Gum");
Console.WriteLine(cart);