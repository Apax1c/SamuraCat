using UnityEngine;

namespace CodeBase.Game.Cats
{
    public class CatAnimator : MonoBehaviour
    {
        [SerializeField] private Animator Animator;

        private static readonly int IsDragging = Animator.StringToHash("IsDragging");
        
        public void Drag(bool isDragging) => 
            Animator.SetBool(IsDragging, isDragging);
    }
}