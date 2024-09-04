using TMPro;
using UnityEngine;

namespace CodeBase.Game.Placements
{
    public class Placement : MonoBehaviour, IPlacement
    {
        [SerializeField] private TextMeshPro CatNumberText;

        public void SetNumber(int catNumber)
        {
            CatNumberText.text = catNumber.ToString();
        }

        public void ClearNumber()
        {
            CatNumberText.enabled = false;
        }
    }
}