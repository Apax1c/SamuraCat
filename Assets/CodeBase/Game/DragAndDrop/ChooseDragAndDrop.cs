using CodeBase.Game.Cats;
using CodeBase.Game.GameStateMachine;
using CodeBase.Game.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.DragAndDrop
{
    public class ChooseDragAndDrop : MonoBehaviour
    {
        private const int LeftMouseButton = 0;

        private Camera _camera;
        private bool _isSwiping;

        private Vector3 _startPosition;
        private Vector3 _previousPosition;

        private CatMover _selectedCat;
        private ChosenCatArea _chosenCatArea;
        
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            if (IsChoosingCatState())
            {
                OnClickDown();

                OnSwipe();

                OnClickUp();
            }
        }

        private void OnClickDown()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton) == false)
                return;

            _isSwiping = true;
            _previousPosition = Input.mousePosition;

            if (Physics.Raycast(GetRay(_previousPosition), out RaycastHit hit))
                if (hit.collider.TryGetComponent(out CatMover selectedCat))
                    StartDragging(selectedCat);
        }

        private void OnSwipe()
        {
            if (IsSelectedCatSwiped())
                return;

            _previousPosition = Input.mousePosition;

            Ray touchRay = GetRay(_previousPosition);
            
            if (Physics.Raycast(touchRay, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out ChosenCatArea catPlacement))
                    SetCursorOnPlacement(catPlacement);
                else
                    SetCursorOutFromPlacement(touchRay);
            }
        }

        private void OnClickUp()
        {
            if (IsCatDraggingFinished())
                return;
            
            if (_chosenCatArea)
                _selectedCat.OnCatChosen(_chosenCatArea.GetPlacement());
            else
                _selectedCat.OnDragEnd(_startPosition);
            
            CleanUp();
        }

        private void StartDragging(CatMover selectedCat)
        {
            _selectedCat = selectedCat;
            _selectedCat.OnDragStart();
                    
            _startPosition = _selectedCat.transform.position;
        }

        private void SetCursorOnPlacement(ChosenCatArea chosenCatArea)
        {
            if (chosenCatArea != _chosenCatArea)
            {
                _chosenCatArea = chosenCatArea;
                _selectedCat.transform.position = _chosenCatArea.GetPlacement().gameObject.transform.position;
            }
        }

        private void SetCursorOutFromPlacement(Ray touchRay)
        {
            _chosenCatArea = null;

            Plane plane = new Plane(Vector3.up, new Vector3(0f, 1f, 0f));
            if (plane.Raycast(touchRay, out float hitDistance) && !_chosenCatArea)
            {
                Vector3 point = touchRay.GetPoint(hitDistance);

                _selectedCat.transform.position = point;
            }
        }

        private void CleanUp()
        {
            _chosenCatArea = null;
            _selectedCat = null;
            _isSwiping = false;
        }

        private bool IsChoosingCatState() => 
            _gameStateMachine.GetCurrentState() is ChoosingState;

        private Ray GetRay(Vector3 position) => 
            _camera.ScreenPointToRay(position);

        private bool IsSelectedCatSwiped() => 
            !_isSwiping || _previousPosition == Input.mousePosition || !_selectedCat;

        private bool IsCatDraggingFinished() => 
            Input.GetMouseButtonUp(LeftMouseButton) == false || !_selectedCat;
    }
}