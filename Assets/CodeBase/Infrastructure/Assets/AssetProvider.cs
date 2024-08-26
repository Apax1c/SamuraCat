using UnityEngine;

namespace CodeBase.Infrastructure.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadFromResources(string path) => 
            Resources.Load<GameObject>(path);

        public T LoadFromResources<T>(string path) =>
            LoadFromResources(path).GetComponent<T>();

        public T LoadScriptableObject<T>(string path) where T : ScriptableObject => 
            Resources.Load<T>(path);
    }
}