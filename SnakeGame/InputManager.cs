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
                    _screen.MoveCursor(Screen.Movement.Left);
                    break;
                case ConsoleKey.RightArrow:
                    _screen.MoveCursor(Screen.Movement.Right);
                    break;
                case ConsoleKey.UpArrow:
                    _screen.MoveCursor(Screen.Movement.Up);
                    break;
                case ConsoleKey.DownArrow:
                    _screen.MoveCursor(Screen.Movement.Down);
                    break;
                default:
                    break;
            }
        }
    }
}
