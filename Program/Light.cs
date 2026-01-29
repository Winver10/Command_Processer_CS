using System;
using System.Numerics;
using System.Text;

namespace LightInput
{
    class ColorDrawer
    {
        private bool _isSpace = false;
        private bool _isLink = false;
        private bool _inQuete = false;
        public ConsoleColor GetColorForChar(char c)
        {
            if (c == '"' && !_inQuete) { _inQuete = true; return ConsoleColor.Blue; }
            if (c == '"' && _inQuete) { _inQuete = false; return ConsoleColor.Blue; }
            if (c == ' ' && !_isSpace) { _isSpace = true; _isLink = false; return ConsoleColor.Gray; }
            if (c == '-') { _isLink = true; _isSpace = false ; return ConsoleColor.Gray; }

            if (c != ' ') { _isSpace = false; }
            
                 if (_isLink) return ConsoleColor.Gray;
            else if (_inQuete) return ConsoleColor.Blue;
            else return ConsoleColor.White;
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