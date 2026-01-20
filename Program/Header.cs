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
        public const int GetContent_ID()
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
            if (Content.Count == 0)
            {
                return "";
            }

            string result;
            int j = Content.Count;
            for (int i; i < j; i++)
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
            List<string> cont;

            if (input.Count == 0)
            {
                cont.Add("NO_0");
            }
            else
            {
                input = input.TrimStart('');
                input = input.TrimEnd('');

                
            }
        }
    }
}