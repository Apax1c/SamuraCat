using Unity.Netcode;
using UnityEngine;

namespace CodeBase.Game
{
    public class Player : NetworkBehaviour
    {
        private CatsContainer _catsContainer;

        public void Construct(CatsContainer catsContainer)
        {
            _catsContainer = catsContainer;
        }
    }
}