using CodeBase.Infrastructure.StateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StateFactory>().AsSingle().NonLazy();
            
            Container.Bind<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<GameLoopState>().AsSingle().NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle();
        }
    }
}