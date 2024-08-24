using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        void CreatePlayer();
        void CreateCat();
        void CreateCatsContainer();
    }
}