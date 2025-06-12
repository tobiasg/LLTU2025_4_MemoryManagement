namespace SkalProj_Datastrukturer_Minne
{
    public static class Helpers
    {
        public static string ReverseString(string input)
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

            return reversed;
        }

        public static bool IsParanthesisCorrect(string input)
        {
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

            return stack.Count == 0;
        }
    }
}