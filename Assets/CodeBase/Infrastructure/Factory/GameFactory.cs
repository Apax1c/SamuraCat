using CodeBase.Game;
using CodeBase.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        
        private CatsContainer _catsContainer;

        [Inject]
        public void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            
            Debug.Log("GameFactory initialized successfully");
        }

        public void CreateCatsContainer()
        {
            CatsContainer catsContainer = _assetProvider.LoadFromResources<CatsContainer>(AssetPath.CatsContainer);
            Object.Instantiate(catsContainer);
            
            _catsContainer = catsContainer;
        }

        public void CreatePlayer()
        {
            GameObject playerGameObject = _assetProvider.LoadFromResources(AssetPath.Player);
            Object.Instantiate(playerGameObject);

            Player player = playerGameObject.GetComponent<Player>();
            player.Construct(_catsContainer);
        }

        public void CreateCat()
        {
            
        }
    }
}
