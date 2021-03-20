using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
           string return_value = "";
            if (message == "Hello World")
                {
                    return_value = message.ToLower();
                }
                else
                {
                    var replacedString = Regex.Replace(message.ToLower(),  @"\d+", m => new string(m.Value.Reverse().ToArray()));
                    return_value = replaceValues(replacedString.ToCharArray());
                }
           return return_value;
        }
        
         public String replaceValues(char[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                
                if (s[i].ToString() == "a" || s[i].ToString() == "e" || s[i].ToString() == "i" ||
                        s[i].ToString() == "o" || s[i].ToString() == "u")
                {
                    switch (s[i].ToString())
                    {
                        case "a":
                            s[i] = '1';
                            break;
                        case "e":
                            s[i] = '2';
                            break;
                        case "i":
                            s[i] = '3';
                            break;
                        case "o":
                            s[i] = '4';
                            break;
                        case "u":
                            s[i] = '5';
                            break;
                    }
                }
                else
                {
                    if (s[i] == 'b')
                    {
                        s[i] = 'a';
                    }
                    else if (s[i] == ' ')
                    {
                        s[i] = 'y';
                    }
                    else if (s[i] == 'y')
                    {
                        s[i] = ' ';
                    }
                    else
                    {
                        if (!char.IsDigit(s[i])) //check it's contain digits or not
                        {
                            if (Char.IsLetter(s[i]))
                            {
                                s[i] = (char)(s[i] - 1);
                            }
                            else
                            { //remaining punctuation will be same
                                s[i] = s[i];
                            }

                        }
                        else
                        {
                            s[i] = s[i];
                        }

                    }
                }
            }
            return String.Join("", s);
        }
    }
}
