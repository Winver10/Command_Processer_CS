using System;
using System.Collections.Generic;
using System.Linq;

using Command_Processer;

namespace MainProgram
{
    class MainProgram
    {
        private void Dislay(List<Command> cmds)
        {
            int j = cmds.Count - 1;
            for (int i = 0; i <= j; i++)
            {
                Console.WriteLine(cmds[i].GetAllContent());
            }
        }
        static public void Main()
        {
            List<Command> cmds = new List<Command>();
            Command_Explainer cmexp = new Command_Explainer();

            while (true)
            {
                Console.Write(">");
                List<string> commandAfterExplainde = cmexp.ExplainCommand(Console.ReadLine());
                Command cmd = new Command(cmexp.GetID(), commandAfterExplainde);
                cmds.Add(cmd);
                Dislay(cmds);
            }
        }
    }
}