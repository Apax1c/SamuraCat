using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<IGameFactory>().
                To<GameFactory>().
                AsSingle().
                NonLazy();
        }
    }
}