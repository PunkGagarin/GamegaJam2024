using UnityEngine;

namespace Gameplay.Characters.Player
{

    public class PlayerMovement : MonoBehaviour
    {

        private Rigidbody _rigidbody;

        private bool _isMoving = true;

        private float _accelerationTimer;

        private Vector3 _velocity;

        [SerializeField]
        private float _accelerationTime = 1f;

        [SerializeField]
        private float _accelerationSpeed = .7f;

        [field: SerializeField]
        public float ForwardForce { get; private set; } = 100f;

        [field: SerializeField]
        public float SideForce { get; private set; } = 25;

        [field: SerializeField]
        public float CurrentSpeedThreshold { get; private set; } = 25;

        [field: SerializeField]
        public float MaxSpeedThreshold { get; private set; } = 45;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_isMoving) return;

            _accelerationTimer += Time.deltaTime;

            ClampVelocity();
            Accelerate();
        }

        private void ClampVelocity()
        {
            _velocity = _rigidbody.velocity;
            if (_velocity.z > CurrentSpeedThreshold)
            {
                _rigidbody.velocity = new Vector3(_velocity.x, _velocity.y, CurrentSpeedThreshold);
            }
        }

        private void Accelerate()
        {
            if (_accelerationTimer >= _accelerationTime)
            {
                SpeedUp();

                _accelerationTimer = 0f;
            }
        }

        private void SpeedUp()
        {
            CurrentSpeedThreshold += _accelerationSpeed;

            if (CurrentSpeedThreshold > MaxSpeedThreshold)
                CurrentSpeedThreshold = MaxSpeedThreshold;
        }


        private void FixedUpdate()
        {
            if (!_isMoving) return;

            _rigidbody.AddForce(0, 0, ForwardForce * Time.fixedDeltaTime);

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                MoveToRight();
            }

            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                MoveToLeft();
            }
        }

        private void MoveToRight()
        {
            MoveToSide(1f);
        }

        private void MoveToLeft()
        {
            MoveToSide(-1f);
        }

        private void MoveToSide(float speedMultiplier)
        {
            _rigidbody.AddForce(new Vector3(SideForce * speedMultiplier * Time.fixedDeltaTime, 0, 0),
                ForceMode.VelocityChange);
        }

        public void StopMovement()
        {
            _isMoving = false;
        }

        public void StartMovement()
        {
            _isMoving = true;
        }

        public void ChangeSpeed(float speedMultiplier)
        {
            ForwardForce *= speedMultiplier;
            SideForce *= speedMultiplier;
        }
    }

}