using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class InputManager
    {
        Screen _screen;
        public InputManager(Screen screen)
        {
            _screen = screen;
        }

        public void ReadInput()
        {
            var key = Console.ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    _screen.MoveCursorLeft();
                    break;
                case ConsoleKey.RightArrow:
                    _screen.MoveCursorRight();
                    break;
                case ConsoleKey.UpArrow:
                    _screen.MoveCursorUp();
                    break;
                case ConsoleKey.DownArrow:
                    _screen.MoveCursorDown();
                    break;
                default:
                    break;
            }
        }
    }
}
