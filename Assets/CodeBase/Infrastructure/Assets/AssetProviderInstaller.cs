using Zenject;

namespace CodeBase.Infrastructure.Assets
{
    public class AssetProviderInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle()
                .NonLazy();
    }
}