using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameStateManager
    {
        GameStates _state = GameStates.NotStarted;
        Action _callback;

        public GameStateManager(Action gameFinishedCallback)
        {
            _callback = gameFinishedCallback;
        }

        public GameStates GetGameState()
        {
            return _state;
        }

        public void SetGameState(GameStates state)
        {
            _state = state;

            if (_state == GameStates.GameEnded)
                _callback.Invoke();
        }

        public enum GameStates
        {
            NotStarted = 0,
            GameInProgress,
            GameEnded
        }
    }
}
