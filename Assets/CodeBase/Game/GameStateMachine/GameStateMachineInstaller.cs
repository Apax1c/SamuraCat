using CodeBase.Game.GameStateMachine.GameStates;
using Zenject;

namespace CodeBase.Game.GameStateMachine
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterStates();
            RegisterStateMachine();
        }

        private void RegisterStates()
        {
            Container.Bind<ChoosingCatState>().AsSingle().NonLazy();
            Container.Bind<ChoosingPlaceState>().AsSingle().NonLazy();
        }

        private void RegisterStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
    }
}