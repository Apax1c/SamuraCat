using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Placement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        void CreatePlayer();
        void CreateCatsContainer();
        void CreateCats();
        CatsContainer GetCatsContainer();
        Player GetPlayer();
        List<ChosenCatPlacement> CreateChoosePlacement(int count, Transform parent);
    }
}