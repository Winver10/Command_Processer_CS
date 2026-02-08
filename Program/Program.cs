/*Copyright 2026 SmileCai

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

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
            int counter = 0;

            while (true)
            {
                Console.Write(">");
                string line = LightInput.Input.GetInput(null);
                if (line == PlaceHolders.PlaceHolder.PlaceHolderForMoreActon + "_UPARROW" && counter > 0)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.Write(">");
                    line = LightInput.Input.GetInput(cmds[counter - 1].GetAllContent());
                    counter--;
                }

                if (line == PlaceHolders.PlaceHolder.PlaceHolderForMoreActon + "_DOWNARROW" && counter < cmds.Count)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.Write(">");
                    line = LightInput.Input.GetInput(cmds[counter + 1].GetAllContent()); 
                    counter++;
                }
                    
                Command cmd = new Command(cmexp.getID(), cmexp.ExplainCommand(line));
                cmds.Add(cmd);
                counter = cmexp.getID();
                Display(cmds);
            }
        }
    }
}