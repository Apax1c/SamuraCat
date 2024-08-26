using CodeBase.Infrastructure.Assets;
using CodeBase.StaticData;
using UnityEngine;
using CodeBase.StaticData.ScriptableObjects;

namespace CodeBase.Game.Cat
{
    public class CatModel : MonoBehaviour
    {
        private CatData _catData;
        private IAssetProvider _assetProvider;

        public void Construct(CatData catData, IAssetProvider assetProvider)
        {
            _catData = catData;
            _assetProvider = assetProvider;
        }

        public void SetModel()
        {
            CatsSO catsSo = _assetProvider.LoadScriptableObject<CatsSO>(AssetPath.CatsSO);

            foreach (CatsStaticData catsStaticData in catsSo.Cats)
            {
                if (catsStaticData.Type == _catData.Type) 
                    Instantiate(catsStaticData.Model, transform);
            }
        }
    }
}