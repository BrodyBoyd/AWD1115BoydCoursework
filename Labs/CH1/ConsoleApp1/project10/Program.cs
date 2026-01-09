using project10;

Product item1 = new("Apple", "123", 2.50m, new ShippingDimensions { Height = 1, Length = 2, Width = 5} );
//Product item2 = new("Apple", "123", 2.50m);

decimal price = item1.Price;

decimal discount = .20m;

decimal discountedPrice = price * (1 - discount);

Product item3 = item1 with { Price = discountedPrice };

//item1.Price = 10.99m;  You get a build error when trying to do this as you can not change record data

ShippingDimensions dims = new(12, 11, 51);

Console.WriteLine(dims);
dims.Length = 15.0;  //Allows you to change it
Console.WriteLine(dims);
Console.WriteLine("----------------");

Console.WriteLine(item1.Name);
Console.WriteLine(item1.Price);
Console.WriteLine(item1.Sku);
Console.WriteLine(item1.Dimensions);
Console.WriteLine("----------------");

Console.WriteLine("Original Item: " + item1);
Console.WriteLine("discounted Item: " + item3);