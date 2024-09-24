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
                        CheckParanthesis();
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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

