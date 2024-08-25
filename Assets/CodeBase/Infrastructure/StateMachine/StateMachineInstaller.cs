using CodeBase.Infrastructure.StateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterStateFactory();
            RegisterStates();
            RegisterStateMachine();
        }

        private void RegisterStateFactory()
        {
            Container.Bind<StateFactory>().AsSingle().NonLazy();
        }

        private void RegisterStates()
        {
            Container.Bind<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<GameLoopState>().AsSingle().NonLazy();
        }

        private void RegisterStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
    }
}