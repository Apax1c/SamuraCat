using CodeBase.Infrastructure.Assets;
using CodeBase.StaticData;
using UnityEngine;
using CodeBase.StaticData.ScriptableObjects;

namespace CodeBase.Game.Cat
{
    public class CatModel : MonoBehaviour
    {
        private CatConstructor _catConstructor;
        private IAssetProvider _assetProvider;

        public void Construct(CatConstructor catConstructor, IAssetProvider assetProvider)
        {
            _catConstructor = catConstructor;
            _assetProvider = assetProvider;
        }

        public void SetModel()
        {
            CatsSO catsSO = _assetProvider.LoadScriptableObject<CatsSO>(AssetPath.CatsSO);

            foreach (CatsData catData in catsSO.Cats)
            {
                if (catData.Type == _catConstructor.Type) 
                    Instantiate(catData.Model, transform);
            }
        }
    }
}