using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessageInBottle
{
    class Program
    {
        static Dictionary<char,string> dictionary = new Dictionary<char, string>();
        static void Main(string[] args)
        {
            
            string firstmsg = Console.ReadLine();
            string secondmsg = Console.ReadLine();
            char currentLetter = ' ';
            var currentCode = new StringBuilder();
            for (var j = 0; j < secondmsg.Length; j++) 
            {
                

                if (secondmsg[j] >= 'A' && secondmsg[j] <= 'Z') 
                {
                    if (currentCode.Length > 0) 
                    {
                        if (!dictionary.ContainsKey(currentLetter))
                        {
                            dictionary.Add(currentLetter, currentCode.ToString());
                        }
                        currentCode.Clear();
                    }
                    currentLetter = secondmsg[j];
                }

                if (secondmsg[j] >= '0' && secondmsg[j] <= '9') 
                {
                    currentCode.Append(secondmsg[j]);
                }
            }

            if (currentCode.Length > 0) 
            {
                if (!dictionary.ContainsKey(currentLetter))
                {
                    dictionary.Add(currentLetter, currentCode.ToString());
                }

                //dictionary.Add(currentLetter, currentCode.ToString());
            }

          

            var newmsg = firstmsg;
            string decodemsg = "";
            //foreach (var letter in dictionary)
            //{

            //    while(newmsg.IndexOf(letter.Value) !=-1)
            //    {
            //        newmsg = newmsg.Replace(letter.Value, letter.Key.ToString());
            //    }
            //}
            Solve(newmsg,decodemsg);
            Console.WriteLine(result.Count);
            result.Sort();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
            
        }
        static List<string> result = new List<string>();
       
        static void Solve(string leftmsg, string decodedmsg) 
        {
            if (leftmsg == string.Empty)
            {
                result.Add(decodedmsg);
                return;
            }

            foreach (var letter in dictionary) 
            {
                if (leftmsg.StartsWith(letter.Value)) 
                {
                    decodedmsg += letter.Key;
                    leftmsg = leftmsg.Remove(0, letter.Value.Length);                   
                    
                    Solve(leftmsg, decodedmsg);
                    
                    leftmsg = letter.Value + leftmsg;
                    decodedmsg = decodedmsg.Remove(decodedmsg.Length - 1);  
                }
                
            }
        }

        
    }
}
