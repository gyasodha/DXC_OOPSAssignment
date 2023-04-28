using System;

public class Furniture
{
    public double Height { get; set; }
    public double Width { get; set; }
    public string Colour { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public virtual void Accept()
    {
        Console.Write("Enter the height: ");
        Height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the width: ");
        Width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter color: ");
        Colour = Console.ReadLine();

        Console.Write("Enter the quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter price: ");
        Price = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Display()
    {
        Console.WriteLine($"Height is: {Height}");
        Console.WriteLine($"Width is: {Width}");
        Console.WriteLine($"Color is: {Colour}");
        Console.WriteLine($"Quantity is: {Quantity}");
        Console.WriteLine($"Price is: {Price}");
    }
}

public class Bookshelf : Furniture
{
    public int Noofshelves { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter number of shelves: ");
        Noofshelves = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Number of shelves: {Noofshelves}");
    }
}

public class DiningTable : Furniture
{
    public int Nooflegs { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter number of legs: ");
        Nooflegs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Number of legs: {Nooflegs}");
    }
}

public class Program
{
    public static int AddToStock(Furniture[] stock)
    {
        int count = 0;

        while (count < stock.Length)
        {
            Console.Write("Enter 'B' for bookshelf or 'D' for dining table: ");
            string choice = Console.ReadLine();

            Furniture furniture;

            if (choice == "B")
            {
                furniture = new Bookshelf();
            }
            else if (choice == "D")
            {
                furniture = new DiningTable();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            furniture.Accept();

            stock[count] = furniture;

            count++;
        }

        return count;
    }

    public static double TotalStockValue(Furniture[] stock)
    {
        double totalValue = 0;

        foreach (Furniture furniture in stock)
        {
            totalValue += furniture.Quantity * furniture.Price;
        }

        return totalValue;
    }

    public static void ShowStockDetails(Furniture[] stock)
    {
        foreach (Furniture furniture in stock)
        {
            furniture.Display();
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        Furniture[] stock = new Furniture[5];

        int count = AddToStock(stock);

        Console.WriteLine($"Total number of furniture details accepted: {count}");
        Console.WriteLine($"Total stock value: {TotalStockValue(stock)}");

        ShowStockDetails(stock);

        Console.ReadLine();
    }
}