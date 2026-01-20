using System;
using System.Collections.Generic;

namespace Command_Processer
{
    class Command
    {
        private int Command_ID;
        private List<string> Content;
        public Command(int id, List<string> cont)
        {
           Command_ID = id;
           Content = new List<string>(cont);
        }
        public int GetContent_ID()
        {
            return Command_ID;
        }
        public void SetCommand_ID(int id)
        {
            Command_ID = id;
        }
        public void SetContent(List<string> cont)
        {
            Content = cont;
        }
        public string GetAllContent()
        {
            if (Content.Count == 0 || Content == null)
            {
                return "";
            }

            string result = "";
            int j = Content.Count;
            for (int i = 1; i < j; i++)
            {
                result += Content[i];
                if (i != Content.Count - 1)
                {
                    result += " ";
                }
            }
            return result;
        }

    }
    class Command_Explainer
    {
        private int ID;
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
                            i++；
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

                    if (current.Length > 0)
                    {
                        cont.Add(current.ToString());
                    }
                }
            }

            return cont;
        }
        public int GetID(){return ID;}
    }
}