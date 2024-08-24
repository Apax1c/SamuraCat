using CodeBase.Infrastructure.Assets;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Bootstrapper>()
                .FromComponentInNewPrefabResource(AssetPath.Bootstrapper)
                .AsSingle()
                .NonLazy();
        }
    }
}