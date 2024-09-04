using System.Collections.Generic;
using CodeBase.Game.Placements;
using CodeBase.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace CodeBase.Game
{
    [RequireComponent(typeof(Collider))]
    public class ChosenCatArea : MonoBehaviour
    {
        private const int CountOfPlacements = 5;
        private const float ZOffset = -0.55f;

        private IGameFactory _gameFactory;
        private List<ChosenPlacement> _placementList = new List<ChosenPlacement>();

        [Inject]
        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void Start()
        {
            _placementList = _gameFactory.CreateChoosePlacement(CountOfPlacements, transform);

            for (int i = 0; i < CountOfPlacements; i++) 
                _placementList[i].transform.localPosition = new Vector3(0f, 0f, ZOffset * i);
        }

        public ChosenPlacement GetPlacement() =>
            _placementList[^1];
    }
}