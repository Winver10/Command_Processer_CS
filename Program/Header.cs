using System;
using System.Collections.Generic;

namespace Command_Processer
{
    class Command //difine a class "Command" to store the info of a command
    {
        private int _Command_ID {  get; set; }
        private List<string> _Content { get; } //the command stored as a List<string>
        public Command(int id, List<string> cont)
        {
           _Command_ID = id;
           _Content = new List<string>(cont);
        }

       public string GetAllContent() //return the command as a line of string
        {
            if (_Content.Count == 0 || _Content == null) //no content
            {
                return "";
            }

            string result = "";//there is content
            int j = _Content.Count;
            for (int i = 0; i < j; i++)
            {
                result += _Content[i];
                if (i != _Content.Count - 1)
                {
                    result += " ";//add space between each picese
                }
            }
            return result;
        }

    }
    class Command_Explainer
    {
        private int ID { get; set; }
        public int getID() { return ID; }

        public List<string> ExplainCommand(string input)
        {
            ID++;
            List<string> cont = new List<string>();

            if (string.IsNullOrEmpty(input))//return "NO_0" to express that there no cotent be inputed
            {
                cont.Add("NO_0");
            }
            else
            {
                input = input.Trim();//erase the space at the start or end

                //a long logic, I don't know how it work, but it just can work
                bool inQuotes = false;
                System.Text.StringBuilder current = new System.Text.StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];

                    if (c == '"')
                    {
                        if (inQuotes && i + 1 < input.Length && input[i + 1] == '"')
                        {
                            current.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = !inQuotes;
                        }
                    }
                    else if (c == ' ' && !inQuotes)
                    {
                        if (current.Length > 0)
                        {
                            cont.Add(current.ToString());
                            current.Clear();
                        }
                    }
                    else
                    {
                        current.Append(c);
                    }

                }
                if (current.Length > 0)
                {
                    cont.Add(current.ToString());
                }

            }

            return cont;
        }
    }
}