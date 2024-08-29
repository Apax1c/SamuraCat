using CodeBase.Infrastructure.Factory;

namespace CodeBase.Game.GameStateMachine.GameStates
{
    public class ChoosingCatState : IGameState
    {
        private readonly IGameFactory _gameFactory;
        
        public ChoosingCatState(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}