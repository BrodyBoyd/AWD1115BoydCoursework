using project11;

Student? student1 = new("Brody", 4);
Student? student2 = new("Alice", 2.5);
Student? student3 = new("Brody", 4);

TempGradeCalc calc = new TempGradeCalc();
double curved = calc.Calc(student2.GPA);

Console.WriteLine("creating students....");
Console.WriteLine(student1);
Console.WriteLine(student2);
Console.WriteLine(student3);
Console.WriteLine("\n");
Console.WriteLine("Using Extension methods....");
Console.WriteLine(student1.GetLetterGrade());
Console.WriteLine("Is honor role: " + student1.IsHonorRole());
Console.WriteLine(student2.GetLetterGrade());
Console.WriteLine("Is honor role: " + student2.IsHonorRole());
Console.WriteLine("\n");
Console.WriteLine("Calucating Grade Curve....");
Console.WriteLine("Origional GPA: " + student2.GPA + ", curved GPA: " + curved);
Console.WriteLine("\n");
Console.WriteLine("Testing null-conditional assignment....");
Console.WriteLine("Attempting to change student 2 name");
Console.WriteLine(student2.Name ??= "Jonny");
Console.WriteLine("Failed! name property is not null");

Console.WriteLine("\n");
bool student1and2 = student1 == student2;
bool student1and3 = student1 == student3;
Console.WriteLine("Testing record equality....");
Console.WriteLine("Are student1 and student2 equal? " + student1and2);
Console.WriteLine("Are student1 and student3 equal? " + student1and3);








