using CodeBase.Game.GameStateMachine;
using CodeBase.Game.GameStateMachine.GameStates;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Game.Cats
{
    public class CatMover : MonoBehaviour
    {
        private const float ScaleDuration = 0.25f;
        
        private Collider _collider;
        private Cat _cat;
        private CatAnimator _catAnimator;
        
        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine, CatAnimator catAnimator)
        {
            _gameStateMachine = gameStateMachine;
            _catAnimator = catAnimator;
        }

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _cat = GetComponent<Cat>();
        }

        public void OnDragStart()
        {
            _collider.enabled = false;
            
            transform.DOScale(0.85f, ScaleDuration);
            _catAnimator.Drag(true);
        }

        public void OnDragEnd(Vector3 startPosition)
        {
            _collider.enabled = true;
            
            DOTween.Sequence()
                .Append(transform.DOMove(startPosition, 0.5f).SetEase(Ease.InOutQuad))
                .Append(transform.DOScale(0.7f, ScaleDuration));
            _catAnimator.Drag(false);
        }

        public void OnCatPlaced(Vector3 newPosition)
        {
            _gameStateMachine.Enter<ChoosingPlaceState>();
            _cat.ChooseCat();

            _collider.enabled = false;
            
            transform.position = newPosition;
            transform.DOScale(0.57f, ScaleDuration);
            _catAnimator.Drag(false);

            RotateCatToCamera();
        }

        private void RotateCatToCamera()
        {
            Vector3 currentPosition = transform.position;
            Vector3 cameraPosition = Camera.main.transform.position;
            float rotationToCameraAngle = (Mathf.Acos((currentPosition.z - cameraPosition.z)/(currentPosition.x - cameraPosition.x)) - Mathf.PI)* 57.3f;
            transform.DORotate(new Vector3(0, rotationToCameraAngle, 0), 1f);
        }
    }
}