using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3___Validate_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestGenerator.GenerateTests(); return;

            int strings = int.Parse(Console.ReadLine());
            HTMLValidator validator = new HTMLValidator();
            for (int i = 1; i <= strings; i++)
            {
                string htmlCode = Console.ReadLine();
                bool isValidHTMLCode = validator.ValidateHTML(htmlCode);
                if (isValidHTMLCode)
                {
                    Console.WriteLine("VALID");
                }
                else
                {
                    Console.WriteLine("INVALID");
                }
            }
        }
    }

    class HTMLValidator
    {
        public bool ValidateHTML(string htmlCode)
        {
            Stack<string> elementsStack = new Stack<string>();

            string[] elements = htmlCode.Split(new char[] { '<' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < elements.Length; i++)
            {
                string element = elements[i];
                element = element.Substring(0, element.Length - 1); // Removing > at the end

                if (element[0] == '/') // Closing tag
                {
                    element = element.Substring(1); // Removing / at the beginning
                    if (elementsStack.Count == 0)
                    {
                        // Not enough opening tags
                        return false;
                    }
                    else
                    {
                        string elementFromStack = elementsStack.Pop();
                        if (elementFromStack != element)
                        {
                            // This closing element does not corresponds to the previous opened
                            return false;
                        }
                    }
                }
                else // Opening tag
                {
                    elementsStack.Push(element);
                }
            }

            if (elementsStack.Count == 0)
            {
                // No errors found
                return true;
            }
            else
            {
                // We have unclosed tags
                return false;
            }
        }
    }
}
