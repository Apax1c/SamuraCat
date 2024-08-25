using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<Cat> _catsList;
        private const float DistanceBetweenCats = 0.74f;

        private void SortCats()
        {
            _catsList = _catsList.OrderBy(b => b.Id).ToList();

            for (int i = 0; i < _catsList.Count; i++)
            {
                Cat cat = _catsList[i];
                float xPosition = -DistanceBetweenCats * (_catsList.Count - 1) / 2 + DistanceBetweenCats * i;
                cat.transform.localPosition = new Vector3(xPosition, 0, 0);
            }
        }

        public void RemoveCat(Cat catToRemove)
        {
            _catsList.Remove(catToRemove);
            SortCats();
        }

        public void UpdateCatsList(List<Cat> cats)
        {
            _catsList = cats;
            SortCats();
        }
    }
}