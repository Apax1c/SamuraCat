using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cat;

namespace SamuraCat.Game.Enemy
{
	public class HardEnemyBehaviour : IEnemyBehaviour
    {
        private List<CatConstructor> _catsList;
        public List<CatConstructor> CatsList
        {
            get { return _catsList; }
            set { _catsList = value; }
        }

        public void UpdateCatsList(List<CatConstructor> newCatsList)
        {
            CatsList = newCatsList;
        }

        public void ChooseCat()
        {
            throw new System.NotImplementedException();
        }
    }
}