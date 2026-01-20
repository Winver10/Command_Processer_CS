using System;
using System.Collections.Generic;

namespace Command_Processer
{
    class Command
    {
        private int Command_ID;
        private List<string> content;
        public Command(int id, List<string> cont)
        {
           Command_ID = id;
           content = new List<string>(cont);
        }
    }
}