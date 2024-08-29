using CodeBase.Game.Cats;
using UnityEngine;

namespace CodeBase.Game
{
    public class Player : MonoBehaviour
    {
        private CatsContainer _catsContainer;

        private Cat _chosenCat;
        
        public void Construct(CatsContainer catsContainer) => 
            _catsContainer = catsContainer;

        public void ChooseCat(Cat cat) => 
            _chosenCat = cat;
    }
}