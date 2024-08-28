using DG.Tweening;
using UnityEngine;

namespace CodeBase.Game.Cats
{
    public class CatMover : MonoBehaviour
    {
        private const float ScaleDuration = 0.25f;
        
        private Collider _collider;
        private CatAnimator _catAnimator;

        public void Construct(CatAnimator catAnimator) => 
            _catAnimator = catAnimator;

        private void Start() => 
            _collider = GetComponent<Collider>();

        public void OnDragStart()
        {
            transform.DOScale(0.85f, ScaleDuration);
            _catAnimator.Drag(true);
            
            _collider.enabled = false;
        }

        public void OnDragEnd(Vector3 startPosition)
        {
            DOTween.Sequence()
                .Append(transform.DOMove(startPosition, 0.5f).SetEase(Ease.InOutQuad))
                .Append(transform.DOScale(0.7f, ScaleDuration));
            _catAnimator.Drag(false);
            
            _collider.enabled = true;
        }

        public void OnCatPlaced(Vector3 newPosition)
        {
            transform.position = newPosition;
            transform.DOScale(0.57f, ScaleDuration);
            _catAnimator.Drag(false);
            
            _collider.enabled = false;
        }
    }
}