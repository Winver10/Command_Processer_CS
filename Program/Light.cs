
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
using System.Numerics;
using System.Text;

namespace LightInput
{
    class Memories
    {
        private bool _isSpace;
        private bool _isLink;
        private bool _inQuete;
        public Memories(bool isSpace, bool isLink, bool inQuete)
        {
            _isSpace = isSpace;
            _isLink = isLink;
            _inQuete = inQuete;
        }
        public bool get_isSpace() { return _isSpace; }
        public bool get_isLink() { return _isLink; }
        public bool get_inQuete() { return _inQuete; }
    }
    class ColorDrawer
    {
        private bool _isSpace = false;
        private bool _isLink = false;
        private bool _inQuete = false;
        private int _conter = -2;
        private List<Memories> DateSaver {get; set;} = new List<Memories>();
        public ConsoleColor GetColorForChar(char c)
        {
            _conter++;
            if (c == '"' && !_inQuete) { _inQuete = true;DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete)); return ConsoleColor.Blue; }
            if (c == '"' && _inQuete) { _inQuete = false;DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete)); return ConsoleColor.Blue; }
            if (c == ' ' && !_isSpace) { _isSpace = true; _isLink = false;DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete)); return ConsoleColor.Gray; }
            if (c == '-' && !_inQuete) { _isLink = true; _isSpace = false ;DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete)); return ConsoleColor.Gray; }

            if (c != ' ') { _isSpace = false; }
            
                 if (_inQuete) {DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete));return ConsoleColor.Blue;}
            else if (_isLink){DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete)); return ConsoleColor.Gray;}
            else {DateSaver.Add(new Memories(_isSpace, _isLink, _inQuete)); return ConsoleColor.White;}
        }
        public void ResetState()
        {
            _isSpace = DateSaver[_conter].get_isSpace();
            _isLink = DateSaver[_conter].get_isLink();
            _inQuete = DateSaver[_conter].get_inQuete();
            _conter--;
            DateSaver.RemoveAt(DateSaver.Count - 1);
        }
        
    }
    public static class Input
    {
        public static string GetInput()
        {
            StringBuilder input = new StringBuilder();
            ConsoleKeyInfo keyinfo;
            ColorDrawer color = new ColorDrawer();

            do
            {
                keyinfo = Console.ReadKey(true);

                if (keyinfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Length--;
                    Console.Write("\b \b");
                    color.ResetState();
                    continue;
                    
                }

                if (!char.IsControl(keyinfo.KeyChar))
                {
                    Console.ForegroundColor = color.GetColorForChar(keyinfo.KeyChar);
                    Console.Write(keyinfo.KeyChar);
                    Console.ResetColor();

                    input.Append(keyinfo.KeyChar);
                }
            } while (keyinfo.Key != ConsoleKey.Enter);
            Console.Write('\n');
            return input.ToString();
        }
    }
}