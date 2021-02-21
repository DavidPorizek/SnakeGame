using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    static class ListEx
    {
        public static void RemoveFrom<T>(this List<T> lst, int from)
        {
            lst.RemoveRange(from, lst.Count - from);
        }
    }

    public class Screen
    {
        public static int _startingCursorPositionX = 0;
        public static int _startingCursorPositionY = 1;

        int _height;
        int _width;
        int _cursorPositionX = _startingCursorPositionX;
        int _cursorPositionY = _startingCursorPositionY;

        int _appleX = 0;
        int _appleY = 0;
        bool _appleExists = false;

        GameStateManager _stateManager;
        List<(int x, int y)> _previousPositions = new List<(int x, int y)> { (_startingCursorPositionX, _startingCursorPositionY) };

        public enum Movement
        {
            Left,
            Right,
            Up,
            Down
        }

        public Screen(GameStateManager stateManager, int height = 20, int width = 50)
        {
            _stateManager = stateManager;
            _height = height;
            _width = width;
            Console.Clear();
        }

        public void SetPixel(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public void EatApple()
        {
            _appleX = 0;
            _appleY = 0;
            _appleExists = false;

            _stateManager.AddHealth();

            // Draw UI again to update the score
            DrawUI();
        }

        public void DrawApple()
        {
            if (_appleExists)
            {
                SetPixel(_appleX, _appleY, '*');
                return;
            }

            var rand = new Random();
            _appleX = rand.Next(_startingCursorPositionX, _width);
            _appleY = rand.Next(_startingCursorPositionY, _height);

            SetPixel(_appleX, _appleY, '*');
            _appleExists = true;
        }

        public void DrawTail()
        {
            // +1 in case we run into a situation where we eat an apple and on the next frame we need to extend by one
            var requiredHistory = _stateManager.GetHealth() + 1;

            if (_previousPositions.Count > requiredHistory)
            {
                _previousPositions.RemoveFrom(requiredHistory);
                var pos = _previousPositions.Last();
                SetPixel(pos.x, pos.y, ' ');
            }

            foreach (var pos in _previousPositions.Take(_stateManager.GetHealth()))
            {
                SetPixel(pos.x, pos.y, 'o');
            }
        }

        public void DrawUI()
        {
            Console.SetCursorPosition(0, 0);

            Console.Write("Player 1");
            var score = _stateManager.GetHealth() - GameStateManager._startingHealth;
            var text = "Score: " + score.ToString();
            Console.CursorLeft = Console.BufferWidth - text.Length;
            Console.Write(text);
        }

        public void DrawScreen()
        {
            DrawTail();
            SetPixel(_cursorPositionX, _cursorPositionY, 'x');

            DrawApple();

            _previousPositions.Insert(0, (_cursorPositionX, _cursorPositionY));
        }

        public void MoveCursor(Movement move)
        {
            switch(move)
            {
                case Movement.Up:
                    MoveCursorUp();
                    break;
                case Movement.Down:
                    MoveCursorDown();
                    break;
                case Movement.Left:
                    MoveCursorLeft();
                    break;
                case Movement.Right:
                    MoveCursorRight();
                    break;
                default:
                    break;
            }

            var bHitWall = _cursorPositionX < 0 || _cursorPositionX > _width || _cursorPositionY < 1 || _cursorPositionY > _height;

            if (bHitWall && !m_bWalkableWalls)
            {
                _stateManager.SetGameState(GameStateManager.GameStates.GameEnded);
            }
            if (_appleX == _cursorPositionX && _appleY == _cursorPositionY)
            {
                EatApple();
            }
        }
        
        public void MoveCursorLeft()
        {
            _cursorPositionX--;
        }

        public void MoveCursorRight()
        {
            _cursorPositionX++;
        }

        public void MoveCursorUp()
        {
            _cursorPositionY--;
        }

        public void MoveCursorDown()
        {
            _cursorPositionY++;
        }

        bool m_bOutline = false; // Whether outline of the playfield is generated or not
        bool m_bWalkableWalls = false; // Whether the walls can be snaked through
        int m_iRefreshRate = 1; // Frames per second
    }
}
