using CodeBase.Infrastructure.GlobalStateMachine.States;

namespace CodeBase.Infrastructure.GlobalStateMachine
{
    public interface IStateMachine
    {
        void Initialize();
        void Enter<TState>() where TState : IState;
    }
}