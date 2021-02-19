using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Screen
    {
        int _height = 100;
        int _width = 100;
        int _cursorPositionX = 0;
        int _cursorPositionY = 0;
        GameStateManager _stateManager;

        public Screen(GameStateManager stateManager, int height = 100, int width = 100)
        {
            _stateManager = stateManager;
            _height = height;
            _width = width;
            Console.Clear();
        }

        public void DrawScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(_cursorPositionX, _cursorPositionY);
            Console.Write("*");
        }
        
        public void MoveCursorLeft()
        {
            _cursorPositionX--;
            if (_cursorPositionX < 0 && !m_bWalkableWalls)
            {
                _stateManager.SetGameState(GameStateManager.GameStates.GameEnded);
            }
                
        }

        public void MoveCursorRight()
        {
            _cursorPositionX++;
            if (_cursorPositionX > _width && !m_bWalkableWalls)
            {
                _stateManager.SetGameState(GameStateManager.GameStates.GameEnded);
            }

        }

        public void MoveCursorUp()
        {
            _cursorPositionY--;
            if (_cursorPositionY < 0 && !m_bWalkableWalls)
            {
                _stateManager.SetGameState(GameStateManager.GameStates.GameEnded);
            }

        }

        public void MoveCursorDown()
        {
            _cursorPositionY++;
            if (_cursorPositionY > _height && !m_bWalkableWalls)
            {
                _stateManager.SetGameState(GameStateManager.GameStates.GameEnded);
            }

        }

        bool m_bOutline = false; // Whether outline of the playfield is generated or not
        bool m_bWalkableWalls = false; // Whether the walls can be snaked through
        int m_iRefreshRate = 1; // Frames per second
    }
}
