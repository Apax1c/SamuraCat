﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private IState _currentState;
        private Dictionary<Type, IState> _states;

        private readonly StateFactory _stateFactory;
        
        public GameStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
                [typeof(GameLoopState)] = _stateFactory.CreateState<GameLoopState>(),
            };
            
            Enter<BootstrapState>();
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();

            IState state = _states[typeof(TState)];
            _currentState = state;
            state.Enter();
        }
    }
}