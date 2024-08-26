using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Cat;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<CatConstructor> _catsList;
        private const float DistanceBetweenCats = 0.74f;

        private void SortCats()
        {
            _catsList = _catsList.OrderBy(b => b.Id).ToList();

            for (int i = 0; i < _catsList.Count; i++)
            {
                CatConstructor catConstructor = _catsList[i];
                float xPosition = -DistanceBetweenCats * (_catsList.Count - 1) / 2 + DistanceBetweenCats * i;
                catConstructor.transform.localPosition = new Vector3(xPosition, 0, 0);
            }
        }

        public void RemoveCat(CatConstructor catConstructorToRemove)
        {
            _catsList.Remove(catConstructorToRemove);
            SortCats();
        }

        public void UpdateCatsList(List<CatConstructor> cats)
        {
            _catsList = cats;
            SortCats();
        }
    }
}