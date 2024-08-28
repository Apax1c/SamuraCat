namespace CodeBase.Infrastructure.GlobalStateMachine.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}