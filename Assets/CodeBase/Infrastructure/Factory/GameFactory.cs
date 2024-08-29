using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cats;
using CodeBase.Game.GameStateMachine;
using CodeBase.Infrastructure.Assets;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const int CountOfCatsOnStart = 10;
        
        private CatsContainer _catsContainer;
        private Player _player;
        private readonly List<Cat> _catsList = new();
        
        private readonly List<int> _catsIdList = new();
        private readonly List<GameObject> _platformsList = new();

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

            for (int i = 0; i < CountOfCatsOnStart; i++)
            {
                GameObject platform = Object.Instantiate(_assetProvider.LoadFromResources(AssetPath.Platform), _catsContainer.transform);
                _platformsList.Add(platform);
            }
            
            _catsContainer.Construct(_platformsList);
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
                int randomId = GetRandomCatId();
                GameObject cat = CreateCat(randomId);
                
                SetCatMover(cat);
            }
            
            _catsContainer.UpdateCatsList(_catsList);
        }

        public CatsContainer GetCatsContainer() => 
            _catsContainer;

        public Player GetPlayer() => 
            _player;
        
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

        private GameObject CreateCat(int catId)
        {
            Cat cat = SetType(catId);

            cat.transform.SetParent(_catsContainer.transform);
            cat.Construct(catId, _catsContainer, _player);
            
            _catsList.Add(cat);

            return cat.gameObject;
        }

        private void SetCatMover(GameObject cat)
        {
            CatMover catMover = cat.GetComponent<CatMover>();
            CatAnimator catAnimator = cat.GetComponentInChildren<CatAnimator>();
            catMover.Construct(_gameStateMachine, catAnimator);
        }

        private Cat SetType(int catId)
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