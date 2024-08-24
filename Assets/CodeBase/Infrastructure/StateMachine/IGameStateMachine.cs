using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Initialize();
        void Enter<TState>() where TState : IState;
    }
}