using UnityEngine;

namespace CodeBase.Game.GameStateMachine.GameStates
{
    public class ChoosingState : IGameState
    {
        public void Enter()
        {
            Debug.Log("ChoosingState");
        }

        public void Exit()
        {
        }
    }
}