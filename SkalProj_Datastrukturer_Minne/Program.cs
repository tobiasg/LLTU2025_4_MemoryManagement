using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            bool exit = false;

            List<string> items = new List<string>();

            while (!exit)
            {

                Console.WriteLine($"Count: {items.Count}, Capacity: {items.Capacity}");

                string input = Console.ReadLine() ?? "";
                // check input length
                char nav = input[0];
                string value = input.Substring(1);

                if (input == "exit") {
                    exit = true;
                    continue;
                }

                switch (nav)
                {
                    case '+':
                        items.Add(value);
                        Console.WriteLine($"Added \"{value}\" to list");
                        break;
                    case '-':
                        if(items.Remove(value))
                        {
                            Console.WriteLine($"Removed \"{value}\" from list");
                        } 
                        else
                        {
                            Console.WriteLine($"\"{value}\" not in list");
                        }
                        break;
                    default:
                        Console.WriteLine("Use + or -");
                        break;
                }
            }

            /*
             * 2. När ökar listans kapacitet?
             * Den underliggaden arrayen ökar i storlek när den är full
             * 
             * 3. Med hur mycket ökar kapaciteten?
             * Den börjar med 0 i kapacitet och när ett element läggs till ökar den till 4 och sen dubblerar den i storlek, 4 -> 8 -> 16 ...
             * 
             * 4. Varfär ökar inte listans kapacitet i samma takt som element läggs till?
             * För att inte den interna arrayen ska kopieras och skapas om varje gång ett element läggs till
             * 
             * 5. Minskar kapaciteten när element tas bort ut listan?
             * Nej, gissar på grund av prestandaskäl
             * 
             * 6. När är det då fördelaktigt att använda en egendefinerad array istället för en lista?
             * När man vill själv kontrollera storleken
             */
        }

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

            bool exit = false;

            Queue<string> items = new Queue<string>();

            while (!exit)
            {
                if (items.Count == 0)
                {
                    Console.WriteLine("Queue is empty");
                    
                } 
                else
                {
                    Console.WriteLine($"Count: {items.Count}");
                    Console.WriteLine($"Next value to be removed from queue: {items.Peek()}");
                }

                string input = Console.ReadLine() ?? "";
                // check input length
                char nav = input[0];
                string value = input.Substring(1);

                if (input == "exit")
                {
                    exit = true;
                    continue;
                }

                switch (nav)
                {
                    case '+':
                        items.Enqueue(value);
                        Console.WriteLine($"Added \"{value}\" to queue");
                        break;
                    case '-':
                        if (items.Count != 0)
                        {
                            Console.WriteLine($"Removing {items.Dequeue()}");
                        } 
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;
                    default:
                        Console.WriteLine("Use + or -");
                        break;
                }
            }
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

            /*
             * 1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det inte så
             *    smart att använda en stack i det här fallet?
             * 
             *    Kunderna blir inte expedierade i den ordnig de har i kön, därför är det inte smart
             */

            string input = Console.ReadLine() ?? "";
            Console.WriteLine(ReverseString(input));
        }

        private static string ReverseString(string input)
        {
            string reversed = "";
            Stack<char> chars = new Stack<char>();
            foreach (char c in input)
            {
                chars.Push(c);
            }

            while (chars.Count > 0)
            {
                reversed += chars.Pop();
            }

            return $"Original string {input}\nReversed string: {reversed}";
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            bool exit = false;

            while (!exit)
            {

                string input = Console.ReadLine() ?? "";

                if (input == "exit")
                {
                    exit = true;
                }

                Stack<char> stack = new Stack<char>();

                foreach (char c in input)
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        if (c == ')' && stack.Count > 0 && stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else if (c == ']' && stack.Count > 0 && stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else if (c == '}' && stack.Count > 0 && stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                    }
                }

                Console.WriteLine($"Correct: {stack.Count == 0}");
            }
        }
    }
}

