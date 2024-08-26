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
        private const int CountOfCatsOnState = 10;
        
        private CatsContainer _catsContainer;
        private readonly List<CatConstructor> _catsList = new List<CatConstructor>();
        private readonly List<int> _catsIdList = new List<int>();
        
        private IAssetProvider _assetProvider;

        [Inject]
        public void Construct(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void CreateCatsContainer()
        {
            GameObject catsContainerGameObject = _assetProvider.LoadFromResources(AssetPath.CatsContainer);
            CatsContainer catsContainer = Object.Instantiate(catsContainerGameObject).GetComponent<CatsContainer>();

            _catsContainer = catsContainer;
        }

        public void CreatePlayer()
        {
            Player player = GetComponentFromInstantiated<Player>(AssetPath.Player);
            player.Construct(_catsContainer);
        }

        public void CreateCats()
        {
            for (int i = 0; i < CountOfCatsOnState; i++)
            {
                int randomId = GetRandomCatId();
                GameObject cat = CreateCat(randomId);
                
                CatModel catModel = cat.GetComponent<CatModel>();
                catModel.Construct(cat.GetComponent<CatConstructor>(), _assetProvider);
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
            CatConstructor catConstructor = GetComponentFromInstantiated<CatConstructor>(AssetPath.Cat);
            catConstructor.transform.SetParent(_catsContainer.transform);
            
            catConstructor.Construct(catId);
            
            _catsList.Add(catConstructor);

            return catConstructor.gameObject;
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
