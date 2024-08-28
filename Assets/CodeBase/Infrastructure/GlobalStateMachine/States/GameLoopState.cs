using CodeBase.Game.GameStateMachine;
using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.GlobalStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _gameFactory;
        private IGameStateMachine _gameStateMachine;

        public GameLoopState(IGameFactory gameFactory, IGameStateMachine gameStateMachine)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }


        public void Enter()
        {
            _gameFactory.CreateCatsContainer();
            _gameFactory.CreatePlayer();
            _gameFactory.CreateCats();
            
            _gameStateMachine.Initialize();
        }

        public void Exit()
        {
            
        }
    }
}