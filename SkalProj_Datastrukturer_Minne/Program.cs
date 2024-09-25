using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParenthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine($"Current list count: {theList.Count}, capacity: {theList.Capacity}");
                Console.WriteLine("Enter '+item' to add, '-item' to remove, or 'exit' to quit:");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (input.ToLower() == "exit")
                    break;

                if (input.Length < 2)
                {
                    Console.WriteLine("Please use '+' or '-' followed by an item.");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added '{value}' to the list.");
                        break;
                    case '-':
                        if (theList.Remove(value))
                            Console.WriteLine($"Removed '{value}' from the list.");
                        else
                            Console.WriteLine($"'{value}' not found in the list.");
                        break;
                    default:
                        Console.WriteLine("Please use only '+' or '-'.");
                        break;
                }
            }
        }
        
        /*
        När ökar listans kapacitet?
        Listans kapacitet ökar när antalet element överstiger den nuvarande kapaciteten.

        Med hur mycket ökar kapaciteten?
        Kapaciteten fördubblas vanligtvis när den behöver öka. Till exempel, från 4 till 8, sedan till 16, och så vidare.

        Varför ökar inte listans kapacitet i samma takt som element läggs till?
        För att optimera prestanda och minnesanvändning. Att öka kapaciteten innebär att skapa en ny array och kopiera element,
        vilket är kostsamt. Genom att fördubbla kapaciteten minskar vi frekvensen av dessa operationer.

        Minskar kapaciteten när element tas bort ur listan?
        Nej, kapaciteten minskar inte automatiskt när element tas bort. Den behåller den maximala kapacitet den har nått.

        När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            - När du vet den exakta storleken på samlingen i förväg och den inte kommer att ändras.
            - När du behöver optimera minnesanvändningen och inte vill ha någon extra kapacitet.
            - När du behöver absolut bästa prestanda för indexerad åtkomst och inte behöver ändra storlek på samlingen.
            - I prestandakritiska scenarier där overheaden av en List<T> kan vara märkbar.
        */
        
        
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();
            
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add a person to the queue (Enqueue)");
            Console.WriteLine("2. Serve a person from the queue (Dequeue)");
            Console.WriteLine("3. View the person at the front of the queue (Peek)");
            
            try
            {
                while (true)
                {
                    Console.WriteLine("\nCurrent queue: " + (queue.Count > 0 ? string.Join(", ", queue) : "empty"));
                    Console.WriteLine("Number of people in queue: " + queue.Count);

                    char choice = Console.ReadLine()![0];

                    switch (choice)
                    {
                        case '1':
                            Console.Write("Enter the name of the person to add to the queue: ");
                            string name = Console.ReadLine()?.Trim() ?? string.Empty;
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Couldn't add the person to the queue. Please try again.");
                            }

                            queue.Enqueue(name);
                            Console.WriteLine($"{name} has been added to the queue.");
                            break;

                        case '2':
                            if (queue.Count > 0)
                            {
                                string dequeuedPerson = queue.Dequeue();
                                Console.WriteLine($"{dequeuedPerson} has been served and left the queue.");
                            }
                            else
                            {
                                Console.WriteLine("The queue is empty. No one to serve.");
                            }

                            break;

                        case '3':
                            if (queue.Count > 0)
                            {
                                Console.WriteLine($"The person at the front of the queue is: {queue.Peek()}");
                            }
                            else
                            {
                                Console.WriteLine("The queue is empty.");
                            }

                            break;

                        case '0':
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again.");
            }
        }

        /*
            Simulering av ICA-kön:

            1. ICA öppnar och kön till kassan är tom
            Aktuell kö: Ingen
            Antal personer i kön: 0

            2. Kalle ställer sig i kön
            Välj alternativ: 1
            Ange namn på personen: Kalle
            Aktuell kö: Kalle
            Antal personer i kön: 1

            3. Greta ställer sig i kön
            Välj alternativ: 1
            Ange namn på personen: Greta
            Aktuell kö: Kalle, Greta
            Antal personer i kön: 2

            4. Kalle blir expedierad och lämnar kön
            Välj alternativ: 2
            Aktuell kö: Greta
            Antal personer i kön: 1

            5. Stina ställer sig i kön
            Välj alternativ: 1
            Ange namn på personen: Stina
            Aktuell kö: Greta, Stina
            Antal personer i kön: 2

            6. Greta blir expedierad och lämnar kön
            Välj alternativ: 2
            Aktuell kö: Stina
            Antal personer i kön: 1

            7. Olle ställer sig i kön
            Välj alternativ: 1
            Ange namn på personen: Olle
            Aktuell kö: Stina, Olle
            Antal personer i kön: 2
        */

        
        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            
        }

        static void CheckParenthesis()
        {
            Stack<char> stack = new Stack<char>();

            while (true)
            {
                Console.WriteLine("Enter the characters. Legal characters are: () [] {}, or enter 'exit' to quit.");
                Console.Write(">> ");
                
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (input.ToLower() == "exit")
                    return;
                
                bool isBalanced = true; // Keeps being true if no errors are encountered
                int errorPosition = -1; // Used to check which character at what index is causing errors.

                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];

                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        if (stack.Count == 0)
                        {
                            isBalanced = false;
                            errorPosition = i;
                            break;
                        }

                        char top = stack.Pop();

                        if ((c == ')' && top != '(') ||
                            (c == ']' && top != '[') ||
                            (c == '}' && top != '{'))
                        {
                            isBalanced = false;
                            errorPosition = i;
                            break;
                        }
                    }
                }

                if (isBalanced && stack.Count == 0)
                {
                    Console.WriteLine("The input is balanced. All parentheses, brackets, and braces are properly matched.");
                }
                else
                {
                    Console.WriteLine("The input is not balanced.");
                    if (errorPosition != -1)
                    {
                        Console.WriteLine($"Error at position {errorPosition + 1}: Mismatched or extra closing character.");
                    }
                    else if (stack.Count > 0)
                    {
                        Console.WriteLine($"Error: {stack.Count} opening character(s) were not closed.");
                    }
                }

                stack.Clear(); // Clear the stack for the next input
                Console.WriteLine();
            }
        }

    }
}