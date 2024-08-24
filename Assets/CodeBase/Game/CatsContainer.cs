using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        public Cat ChosenCat { get; private set; }
        public bool IsCatChosen => ChosenCat != null;

        private List<Cat> _catsList;
        private const float DistanceBetweenCats = 0.74f;

        public event EventHandler OnCatChosen;
        public event EventHandler OnCatsSet;

        public void SetCat(Cat chosenCat)
        {
            ChosenCat = chosenCat;

            OnCatChosen?.Invoke(this, EventArgs.Empty);
        }

        private void SortCats()
        {
            _catsList = _catsList.OrderBy(b => b.Id).ToList();

            for (int i = 0; i < _catsList.Count; i++)
            {
                Cat cat = _catsList[i];
                cat.transform.SetParent(transform);
                float xPosition = -DistanceBetweenCats * (_catsList.Count - 1) / 2 + DistanceBetweenCats * i;
                cat.transform.localPosition = new Vector3(xPosition, 0, 0);
            }
        }

        public void RemoveCat(Cat catToRemove)
        {
            _catsList.Remove(catToRemove);
            SortCats();

            OnCatChosen?.Invoke(this, EventArgs.Empty);
        }

        public void FulfillCatsList(List<Cat> cats)
        {
            OnCatsSet?.Invoke(this, EventArgs.Empty);

            _catsList = cats;
            SortCats();
        }
    }
}