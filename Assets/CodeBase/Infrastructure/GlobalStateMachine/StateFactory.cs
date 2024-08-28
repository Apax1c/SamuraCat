using CodeBase.Game.GameStateMachine;
using CodeBase.Infrastructure.GlobalStateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.GlobalStateMachine
{
    public class StateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) => 
            _container = container;

        public T CreateState<T>() where T : IState => 
            _container.Resolve<T>();

        public T CreateGameState<T>() where T : IGameState => 
            _container.Resolve<T>();
    }
}