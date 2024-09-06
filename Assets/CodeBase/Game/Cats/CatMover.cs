using CodeBase.Game.GameStateMachine;
using CodeBase.Game.GameStateMachine.GameStates;
using CodeBase.Game.Placements;
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

        private Camera _camera;
        
        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine, CatAnimator catAnimator)
        {
            _gameStateMachine = gameStateMachine;
            _catAnimator = catAnimator;
            _camera = Camera.main;
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

        public void OnCatChosen(ChosenPlacement placement)
        {
            _gameStateMachine.Enter<ConfirmingState>();
            _cat.ChooseCat(placement);
            
            _collider.enabled = false;
            
            transform.position = placement.transform.position + Vector3.up * 0.3f;
            transform.DOScale(1f, ScaleDuration);
            _catAnimator.Drag(false);

            RotateCatToCamera();
        }

        public void RotateCatToCamera()
        {
            Vector3 currentPosition = transform.position;
            Vector3 cameraPosition = _camera.transform.position;
            
            Vector3 directionToCamera = cameraPosition - currentPosition;
            directionToCamera.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

            transform.DORotate(targetRotation.eulerAngles, 1f);
        }
    }
}