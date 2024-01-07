using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Gameplay.Obstacles
{

    public class MovingObstacle : MonoBehaviour
    {
        private float _originalXPosition;

        private float _leftBound;
        private float _rightBound;

        private MovingDirection _currentDirection;

        [Inject] private MovingObstaclesController _controller;

        [SerializeField]
        private float _moveRange = 4f;

        [SerializeField]
        private MovingDirection _startDirection;

        [SerializeField]
        private float _speed = 1f;

        // Start is called before the first frame update
        private void Start()
        {
            _originalXPosition = transform.position.x;
            _currentDirection = _startDirection;
            _controller.RegisterObstacle(this);
        }

        public void Init(float leftBorder, float rightBorder)
        {
            _leftBound = leftBorder + transform.localScale.x / 2;
            _rightBound = rightBorder - transform.localScale.x / 2;
        }

        private void Update()
        {
            if (_currentDirection == MovingDirection.Left)
            {
                transform.position += Vector3.left * (_speed * Time.deltaTime);
                CheckForLeftBorder();
            }
            else if (_currentDirection == MovingDirection.Right)
            {
                transform.position += Vector3.right * (_speed * Time.deltaTime);
                CheckForRightBorder();
            }
        }

        private void CheckForLeftBorder()
        {
            if (transform.position.x <= _leftBound || transform.position.x <= _originalXPosition - _moveRange)
            {
                _currentDirection = MovingDirection.Right;
            }
        }

        private void CheckForRightBorder()
        {
            if (transform.position.x >= _rightBound || transform.position.x >= _originalXPosition + _moveRange)
            {
                _currentDirection = MovingDirection.Left;
            }
        }
    }

}