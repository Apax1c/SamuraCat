using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Placements;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        void CreatePlayer();
        void CreateCatsContainer();
        void CreateCats();
        List<ChosenPlacement> CreateChoosePlacement(int count, Transform parent);
        void CreateConfirmedCats();
        void CreateConfirmedRows();
    }
}