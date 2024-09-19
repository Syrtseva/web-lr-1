class Program
{
    static void Main()
    {
        int selectedIndex = 0;
        string[] menuItems = {
            "Display the number of words from 'Lorem ipsum'",
            "Perform a mathematical operation",
            "Exit"
        };
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            ShowMenu(menuItems, selectedIndex);

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    ExecuteMenuOption(selectedIndex);
                    if (selectedIndex == menuItems.Length - 1) exit = true;
                    break;
            }
        }
    }

    static void ShowMenu(string[] items, int selectedIndex)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (i == selectedIndex)
            {
                // Highlight the selected item
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                // Reset colors for non-selected items
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(items[i]);
        }

        // Reset colors after the loop
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void ExecuteMenuOption(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                DisplayLoremIpsumWordCount();
                break;
            case 1:
                PerformMathOperation();
                break;
            case 2:
                Console.WriteLine("Exiting...");
                break;
        }

        if (selectedIndex != 2)
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }

    static void DisplayLoremIpsumWordCount()
    {
        try
        {
            string text = System.IO.File.ReadAllText("lorem.txt");
            Console.Write("Enter the number of words to display: ");
            int count = int.Parse(Console.ReadLine());
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < count && i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void PerformMathOperation()
    {
        try
        {
            Console.Write("Enter the first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Choose an operation (+, -, *, /): ");
            char operation = Console.ReadLine().Trim()[0];
            Console.WriteLine();

            double result = 0;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    return;
            }

            Console.WriteLine("Result: " + result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid numbers.");
        }
    }
}
