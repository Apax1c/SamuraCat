using CodeBase.Game.GameStateMachine;
using CodeBase.Game.GameStateMachine.GameStates;
using CodeBase.Game.Placement;
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

        public void OnCatChosen(ChosenCatPlacement placement)
        {
            _gameStateMachine.Enter<ConfirmingState>();
            _cat.ChooseCat(placement);
            
            _collider.enabled = false;
            
            transform.position = placement.transform.position + Vector3.up * 0.3f;
            transform.DOScale(0.7f, ScaleDuration);
            _catAnimator.Drag(false);

            RotateCatToCamera();
        }

        private void RotateCatToCamera()
        {
            Vector3 currentPosition = transform.position;
            Vector3 cameraPosition = _camera.transform.position;
            float rotationToCameraAngle = (Mathf.Atan((currentPosition.z - cameraPosition.z)/(currentPosition.x - cameraPosition.x)) - Mathf.PI)* 57.3f;
            transform.DORotate(new Vector3(0, rotationToCameraAngle, 0), 1f);
        }
    }
}