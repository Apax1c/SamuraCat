using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cats;
using CodeBase.Game.Cats.Types;
using CodeBase.Game.GameStateMachine;
using CodeBase.Game.Placements;
using CodeBase.Infrastructure.Assets;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const int CountOfCatsOnStart = 10;
        private const int CountOfConfirmedRows = 4;

        private CatsContainer _catsContainer;
        
        private Player _player;
        
        private readonly List<Cat> _catsList = new();
        private readonly List<int> _catsIdList = new();
        
        private readonly List<ChosenPlacement> _choosePlacementsList = new();
        private readonly List<ConfirmedRow> _confirmedRowList = new();

        private IAssetProvider _assetProvider;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IAssetProvider assetProvider, IGameStateMachine gameStateMachine)
        {
            _assetProvider = assetProvider;
            _gameStateMachine = gameStateMachine;
        }

        public void CreateCatsContainer()
        {
            _catsContainer = GetComponentFromInstantiated<CatsContainer>(AssetPath.CatsContainer);

            List<Placement> placements = new();
            for (int i = 0; i < CountOfCatsOnStart; i++)
            {
                Placement placement = GetComponentFromInstantiated<Placement>(AssetPath.Platform);
                placement.transform.SetParent(_catsContainer.transform);
                placements.Add(placement);
            }
            
            _catsContainer.Construct(placements);
        }

        public void CreatePlayer()
        {
            _player = GetComponentFromInstantiated<Player>(AssetPath.Player);
            _player.Construct(_catsContainer);
        }

        public void CreateCats()
        {
            for (int i = 0; i < CountOfCatsOnStart; i++)
            {
                Cat cat = CreateCat();

                cat.transform.SetParent(_catsContainer.transform);
                _catsList.Add(cat);
                
                SetCatMover(cat.gameObject);
            }
            
            _catsContainer.UpdateCatsList(_catsList);
        }

        public List<ChosenPlacement> CreateChoosePlacement(int count, Transform parent)
        {
            _choosePlacementsList.Clear();
            for (int i = 0; i < count; i++)
            {
                ChosenPlacement placement = GetComponentFromInstantiated<ChosenPlacement>(AssetPath.ChoosePlacement);
                placement.transform.SetParent(parent);
                _choosePlacementsList.Add(placement);
            }

            return _choosePlacementsList;
        }

        public void CreateConfirmedRows()
        {
            for (int i = 0; i < CountOfConfirmedRows; i++)
            {
                ConfirmedRow row = GetComponentFromInstantiated<ConfirmedRow>(AssetPath.ConfirmedRow);
                Vector3 newPosition = new Vector3(0, 0, -1.15f * i);
                row.transform.position += newPosition;
                _confirmedRowList.Add(row);
            }
        }

        public void CreateConfirmedCats()
        {
            for (int i = 0; i < CountOfConfirmedRows; i++)
            {
                Cat cat = CreateCat();
                cat.GetComponent<CatMover>().enabled = false;
                _confirmedRowList[i].AddCat(cat);
            }
        }

        private Cat CreateCat()
        {
            int randomId = GetRandomCatId();
            return GetCatWithType(randomId);
        }

        private int GetRandomCatId()
        {
            int randomId;
            do
            {
                randomId = Random.Range(1, 120);
            } while (_catsIdList.Contains(randomId));
            _catsIdList.Add(randomId);
            
            return randomId;
        }

        private void SetCatMover(GameObject cat)
        {
            CatMover catMover = cat.GetComponent<CatMover>();
            CatAnimator catAnimator = cat.GetComponentInChildren<CatAnimator>();
            catMover.Construct(_gameStateMachine, catAnimator);
        }

        private Cat GetCatWithType(int catId)
        {
            const int bigCatId = (int)CatType.Big;
            const int katanaCatId = (int)CatType.Katana;
            const int parkourCatId = (int)CatType.Parkour;
            const int killerCatId = (int)CatType.Killer;
            
            Cat cat;
            if (catId % bigCatId == 0)                 // 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120
                cat = GetComponentFromInstantiated<BigCat>(AssetPath.BigCat);
            else if ((catId - 1) % katanaCatId == 0)   // 9, 19, 29, 39, 49...
                cat = GetComponentFromInstantiated<KatanaCat>(AssetPath.KatanaCat);
            else if ((catId - 2) % parkourCatId == 0)  // 10, 22, 34, 46, 58, 70, 82, 94, 106, 118
                cat = GetComponentFromInstantiated<ParkourCat>(AssetPath.ParkourCat);
            else if ((catId - 4) % killerCatId == 0)   // 20, 44, 68, 92, 116
                cat = GetComponentFromInstantiated<KillerCat>(AssetPath.KillerCat);
            else
                cat = GetComponentFromInstantiated<DefaultCat>(AssetPath.DefaultCat);
            
            cat.Construct(catId, _catsContainer, _player);
            
            return cat;
        }

        private T GetComponentFromInstantiated<T>(string path) where T : class
        {
            GameObject loadedGameObject = _assetProvider.LoadFromResources(path);
            
            T component = Object
                .Instantiate(loadedGameObject)
                .GetComponent<T>();

            return component;
        }
    }
}