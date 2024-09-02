using CodeBase.Infrastructure.Factory;

namespace CodeBase.Game.GameStateMachine.GameStates
{
    public class ChoosingState : IGameState
    {
        private readonly IGameFactory _gameFactory;
        
        public ChoosingState(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}