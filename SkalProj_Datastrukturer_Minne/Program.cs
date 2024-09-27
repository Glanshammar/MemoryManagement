using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static void Main()
        {

            while (true)
            {
                Console.WriteLine(
                    "Please navigate through the application by inputting the number of your choice:"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Check Parenthesis"
                    + "\n5. Reverse String"
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
                    case '5':
                        ReverseText();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            }
        }

        
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
        Q: När ökar listans kapacitet?
        A: Listans kapacitet ökar när antalet element överstiger kapaciteten.

        Q: Med hur mycket ökar kapaciteten?
        A: Kapaciteten fördubblas vanligtvis när den behöver öka. Till exempel, från 4 till 8, sedan till 16, och så vidare.

        Q: Varför ökar inte listans kapacitet i samma takt som element läggs till?
        A: För att optimera prestanda och minnesanvändning. Att öka kapaciteten innebär att skapa en ny array och kopiera element,
        vilket är kostsamt. Genom att fördubbla kapaciteten minskar vi frekvensen av dessa operationer.

        Q: Minskar kapaciteten när element tas bort ur listan?
        A: Nej, kapaciteten minskar inte automatiskt när element tas bort. Den behåller den maximala kapacitet den har nått.
        För att minska på listan så används List.TrimExcess() metoden.

        Q: När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            - När du vet den exakta storleken på samlingen i förväg och den inte kommer att ändras.
            - När du behöver optimera minnesanvändningen och inte vill ha någon extra kapacitet.
            - När du behöver absolut bästa prestanda för indexerad åtkomst och inte behöver ändra storlek på samlingen.
            - I prestandakritiska scenarier där overheaden av en List<T> kan vara märkbar.
        */


        
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
            a. ICA öppnar: []
            b. Kalle ställer sig i kön: [Kalle]
            c. Greta ställer sig i kön: [Kalle, Greta]
            d. Kalle blir expedierad: [Greta]
            e. Stina ställer sig i kön: [Greta, Stina]
            f. Greta blir expedierad: [Stina]
            g. Olle ställer sig i kön: [Stina, Olle]
        */

        
        static void ExamineStack()
        {
            Stack<string> mainStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();

            // Helper function to add a person to the queue
            void AddToQueue(string name)
            {
                mainStack.Push(name);
                Console.WriteLine($"{name} ställer sig i kön: {PrintQueue()}");
            }

            // Helper function to remove a person from the queue
            void RemoveFromQueue()
            {
                if (mainStack.Count == 0) return;

                string person = string.Empty;
                while (mainStack.Count > 1)
                    tempStack.Push(mainStack.Pop());
                
                person = mainStack.Pop();
                while (tempStack.Count > 0)
                    mainStack.Push(tempStack.Pop());
                
                Console.WriteLine($"{person} blir expedierad: {PrintQueue()}");
            }

            string PrintQueue()
            {
                return "[" + string.Join(", ", mainStack.Reverse()) + "]";
            }

            Console.WriteLine("ICA öppnar: []"); // a. ICA öppnar: []
            
            AddToQueue("Kalle"); // b. Kalle ställer sig i kön: [Kalle]
            AddToQueue("Greta"); // c. Greta ställer sig i kön: [Kalle, Greta]
            RemoveFromQueue(); // d. Kalle blir expedierad: [Greta]
            
            AddToQueue("Stina"); // e. Stina ställer sig i kön: [Greta, Stina]
            RemoveFromQueue(); // f. Greta blir expedierad: [Stina]
            
            AddToQueue("Olle"); // g. Olle ställer sig i kön: [Stina, Olle]
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

                bool isBalanced = true; // Flag to track if brackets are balanced
                int errorPosition = -1; // Track position of any error found

                // Iterate through each character in the input
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];

                    // If it's an opening bracket, push it onto the stack
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    // If it's a closing bracket
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        // If stack is empty, we have a closing bracket without an opening one
                        if (stack.Count == 0)
                        {
                            isBalanced = false;
                            errorPosition = i;
                            break;
                        }

                        // Pop the top element from the stack, to check for matching brackets
                        char top = stack.Pop();

                        // Check if the current closing bracket matches the last opening bracket
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

                // If all brackets are balanced and stack is empty, input is valid
                if (isBalanced && stack.Count == 0)
                {
                    Console.WriteLine(
                        "The input is balanced. All parentheses, brackets, and braces are properly matched.");
                }
                else
                {
                    Console.WriteLine("The input is not balanced.");
                    if (errorPosition != -1)
                    {
                        // Report the position of mismatched or extra closing bracket
                        Console.WriteLine(
                            $"Error at position {errorPosition + 1}: Mismatched or extra closing character.");
                    }
                    else if (stack.Count > 0)
                    {
                        // Report the number of unclosed opening brackets
                        Console.WriteLine($"Error: {stack.Count} opening character(s) were not closed.");
                    }
                }

                // Clear the stack for the next input
                stack.Clear();
                Console.WriteLine();
            }
        }
        
        public static void ReverseText()
        {
            Console.Write("Text to be reversed: ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Text is empty.");
                return;
            }

            Stack<char> charStack = new Stack<char>();

            // Add each character to the stack
            foreach (char c in input)
            {
                charStack.Push(c);
            }

            // Creating the reversed string and adds the last character from the Stack<char> to reversedString
            string reversedString = string.Empty;
            while (charStack.Count > 0)
            {
                reversedString += charStack.Pop();
            }

            Console.WriteLine("The reversed text is: " + reversedString);
        }
    }
}