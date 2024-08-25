using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _gameFactory;

        public GameLoopState(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Enter()
        {
            _gameFactory.CreateCatsContainer();
            _gameFactory.CreatePlayer();
        }

        public void Exit()
        {
            
        }
    }
}