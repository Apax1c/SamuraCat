using System;
using System.Collections.Generic;
using CodeBase.Game.GameStateMachine.GameStates;
using CodeBase.Infrastructure.GlobalStateMachine;

namespace CodeBase.Game.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private IGameState _currentState;
        private Dictionary<Type, IGameState> _states;

        private readonly StateFactory _stateFactory;
        
        public GameStateMachine(StateFactory stateFactory) => 
            _stateFactory = stateFactory;

        public void Initialize()
        {
            _states = new Dictionary<Type, IGameState>()
            {
                [typeof(ChoosingCatState)] = _stateFactory.CreateGameState<ChoosingCatState>(),
                [typeof(ChoosingPlaceState)] = _stateFactory.CreateGameState<ChoosingPlaceState>(),
            };
            
            Enter<ChoosingCatState>();
        }

        public void Enter<TState>() where TState : IGameState
        {
            _currentState?.Exit();

            IGameState state = _states[typeof(TState)];
            _currentState = state;
            state.Enter();
        }

        public IGameState GetCurrentState() => 
            _currentState;
    }
}