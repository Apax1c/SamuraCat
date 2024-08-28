using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cats;
using CodeBase.Infrastructure.Assets;
using SamuraCat.Constants;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const int CountOfCatsOnStart = 10;
        
        private CatsContainer _catsContainer;
        private readonly List<Cat> _catsList = new();
        private readonly List<int> _catsIdList = new();
        private readonly List<GameObject> _platformsList = new();
        
        private IAssetProvider _assetProvider;

        [Inject]
        public void Construct(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

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
            Player player = GetComponentFromInstantiated<Player>(AssetPath.Player);
            player.Construct(_catsContainer);
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
            const int bigCatId = (int)CatType.Big;
            const int katanaCatId = (int)CatType.Katana;
            const int parkourCatId = (int)CatType.Parkour;
            const int killerCatId = (int)CatType.Killer;

            Cat cat = SetType(catId, bigCatId, katanaCatId, parkourCatId, killerCatId);

            cat.transform.SetParent(_catsContainer.transform);
            cat.Construct(catId);
            
            _catsList.Add(cat);

            return cat.gameObject;
        }

        private static void SetCatMover(GameObject cat)
        {
            CatMover catMover = cat.GetComponent<CatMover>();
            CatAnimator catAnimator = cat.GetComponentInChildren<CatAnimator>();
            catMover.Construct(catAnimator);
        }

        private Cat SetType(int catId, int bigCatId, int katanaCatId, int parkourCatId, int killerCatId)
        {
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