using System;
using System.Collections.Generic;
using System.Linq;

using Command_Processer;

namespace MainProgram
{
    class MainProgram
    {
        static private void Display(List<Command> cmds)
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
                List<string> commandAfterExplainde = cmexp.ExplainCommand(LightInput.Input.GetInput());
                Command cmd = new Command(cmexp.getID(), commandAfterExplainde);
                cmds.Add(cmd);
                Display(cmds);
            }
        }
    }
}