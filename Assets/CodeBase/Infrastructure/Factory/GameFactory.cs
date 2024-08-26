using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cat;
using CodeBase.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const int CountOfCatsOnStart = 10;
        
        private CatsContainer _catsContainer;
        private readonly List<CatData> _catsList = new();
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
                
                CatModel catModel = cat.GetComponent<CatModel>();
                catModel.Construct(cat.GetComponent<CatData>(), _assetProvider);
                catModel.SetModel();
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
            CatData catData = GetComponentFromInstantiated<CatData>(AssetPath.Cat);
            catData.transform.SetParent(_catsContainer.transform);
            
            catData.Construct(catId);
            
            _catsList.Add(catData);

            return catData.gameObject;
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