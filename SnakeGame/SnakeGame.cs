using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeGameCore
    {
        static void Main()
        {
            Console.CursorVisible = false;

            GameStateManager _stateManager = new GameStateManager(EndGame);
            Screen _screen = new Screen(_stateManager);
            InputManager _inputManager = new InputManager(_screen);

            _stateManager.SetGameState(GameStateManager.GameStates.GameInProgress);

            while (_stateManager.GetGameState() != GameStateManager.GameStates.GameEnded)
            {
                _screen.DrawScreen();
                _inputManager.ReadInput();
            }
        }

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Nub");
            Console.ReadKey();
        }
    }
}
