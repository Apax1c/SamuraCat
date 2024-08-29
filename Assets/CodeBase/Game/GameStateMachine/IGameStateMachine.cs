namespace CodeBase.Game.GameStateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IGameState;
        void Initialize();
        public IGameState GetCurrentState();
    }
}