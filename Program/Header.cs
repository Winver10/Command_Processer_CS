using System;
using System.Collections.Generic;

namespace Command_Processer
{
    class Command
    {
        private int _Command_ID;
        private List<string> _Content;
        public Command(int id, List<string> cont)
        {
           _Command_ID = id;
           _Content = new List<string>(cont);
        }

        public int Command { get; set;}
        public List<string> Content {get;}

        public string GetAllContent()
        {
            if (_Content.Count == 0 || _Content == null)
            {
                return "";
            }

            string result = "";
            int j = _Content.Count;
            for (int i = 0; i < j; i++)
            {
                result += _Content[i];
                if (i != _Content.Count - 1)
                {
                    result += " ";
                }
            }
            return result;
        }

    }
    class Command_Explainer
    {
        private int _ID;
        public List<string> ExplainCommand(string input)
        {
            ID++;
            List<string> cont = new List<string>();

            if (string.IsNullOrEmpty(input))
            {
                cont.Add("NO_0");
            }
            else
            {
                input = input.Trim();

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
        public int ID{get {return _ID;}}
    }
}