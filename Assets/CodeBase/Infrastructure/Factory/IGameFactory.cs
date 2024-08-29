using CodeBase.Game;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        void CreatePlayer();
        void CreateCatsContainer();
        void CreateCats();
        CatsContainer GetCatsContainer();
        Player GetPlayer();
    }
}