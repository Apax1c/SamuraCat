using CodeBase.Infrastructure;
using Zenject;

namespace CodeBase.Services.SceneLoader
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Bootstrapper bootstrapper = Container.Resolve<Bootstrapper>();

            Container.Bind<SceneLoader>().AsSingle().WithArguments(bootstrapper);
        }
    }
}