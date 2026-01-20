using System;
using System.Collections.Generic;
using System.Linq

using Command_Processer;

namespace MainProgram
{
    class MainProgram
    {
        private void Dislay(List<Command> cmds)
        {
            int j = cmds.Count - 1;
            for (int i = 0; i == j; i++)
            {
                Console.WriteLine(cmds[i].GetAllContent());
            }
        }
        static public void Main()
        {
            List<Command> cmds;
            Command_Explainer cmexp;

            Console.Write(">");
            while (true)
            {
                Command cmd;
                cmd.SetContent(cmexp.ExplainCommand(Console.ReadLine()));
                cmd.SetCommand_ID(cmexp.GetID());
                cmds.Add(cmd);
            }
        }
    }
}