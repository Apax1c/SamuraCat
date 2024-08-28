using CodeBase.Game.Cats;
using UnityEngine;

namespace CodeBase.Game
{
    public class DragAndDropHandler : MonoBehaviour
    {
        private const int LeftMouseButton = 0;

        private Camera _camera;
        private bool _isSwiping;

        private Vector3 _startPosition;
        private Vector3 _previousPosition;

        private CatMover _selectedCat;
        private CatPlacement _catPlacement;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            OnClickDown();

            OnSwipe();

            OnClickUp();
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
                if (hit.collider.TryGetComponent(out CatPlacement catPlacement))
                    SetCursorOnPlacement(catPlacement);
                else
                    SetCursorOutFromPlacement(touchRay);
            }
        }

        private void OnClickUp()
        {
            if (IsCatDraggingFinished())
                return;
            
            if (_catPlacement)
                _selectedCat.OnCatPlaced(_catPlacement.transform.position);
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

        private void SetCursorOnPlacement(CatPlacement catPlacement)
        {
            if (catPlacement != _catPlacement)
            {
                _catPlacement = catPlacement;
                _selectedCat.transform.position = _catPlacement.transform.position;
            }
        }

        private void SetCursorOutFromPlacement(Ray touchRay)
        {
            _catPlacement = null;

            Plane plane = new Plane(Vector3.up, new Vector3(0f, 1f, 0f));
            if (plane.Raycast(touchRay, out float hitDistance) && !_catPlacement)
            {
                Vector3 point = touchRay.GetPoint(hitDistance);

                _selectedCat.transform.position = point;
            }
        }

        private void CleanUp()
        {
            _catPlacement = null;
            _selectedCat = null;
            _isSwiping = false;
        }

        private Ray GetRay(Vector3 position) => 
            _camera.ScreenPointToRay(position);

        private bool IsSelectedCatSwiped() => 
            !_isSwiping || _previousPosition == Input.mousePosition || !_selectedCat;

        private bool IsCatDraggingFinished() => 
            Input.GetMouseButtonUp(LeftMouseButton) == false || !_selectedCat;
    }
}