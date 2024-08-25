using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const int CountOfCatsOnState = 10;
        
        private CatsContainer _catsContainer;
        private readonly List<Cat> _catsList = new List<Cat>();
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
                CreateCat(randomId);
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

        private void CreateCat(int catId)
        {
            Cat cat = GetComponentFromInstantiated<Cat>(AssetPath.Cat);
            cat.transform.SetParent(_catsContainer.transform);
            
            cat.Construct(catId);
            
            _catsList.Add(cat);
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
