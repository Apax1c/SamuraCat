using CodeBase.Game.Cats;
using TMPro;
using UnityEngine;

namespace CodeBase.Game.Placements
{
    public class ConfirmedPlacement : MonoBehaviour, IPlacement
    {
        [SerializeField] private TextMeshPro CatNumberText;
        public bool IsCatSet { get; private set; } = false;

        public void SetCat(Cat cat)
        {
            cat.transform.SetParent(transform);
            cat.transform.localPosition = new Vector3(0f, 0.45f, 0f);
            SetNumber(cat.ID);
        }
        
        public void SetNumber(int catNumber)
        {
            IsCatSet = true;
            CatNumberText.text = catNumber.ToString();
        }

        public void ClearNumber()
        {
            IsCatSet = false;
            CatNumberText.enabled = false;
        }
    }
}