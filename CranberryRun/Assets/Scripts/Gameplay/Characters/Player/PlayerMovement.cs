using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player
{

    public class PlayerMovement : MonoBehaviour
    {

        private Rigidbody _rigidbody;

        private bool _isMoving = true;

        private float _accelerationTimer;

        private float _currentForwardForce;


        [SerializeField]
        private float _accelerationTime = 1f;

        [SerializeField]
        private float _accelerationProcent = .7f;

        [SerializeField]
        private float _accelerationMax = 500f;

        [field: SerializeField]
        public float ForwardForce { get; private set; } = 100f;

        [field: SerializeField]
        public float SideForce { get; private set; } = 25;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentForwardForce = ForwardForce;
        }

        private void Update()
        {
            if (!_isMoving || _currentForwardForce >= _accelerationMax) return;

            Accelerate();
        }

        private void Accelerate()
        {
            if (_accelerationTimer >= _accelerationTime)
            {
                var percentMultiplier = 1f + (_accelerationProcent / 100f);
                _currentForwardForce *= percentMultiplier;

                _accelerationTimer = 0f;
            }
            _accelerationTimer += Time.deltaTime;
        }


        private void FixedUpdate()
        {
            if (!_isMoving) return;

            _rigidbody.AddForce(0, 0, _currentForwardForce * Time.fixedDeltaTime);

            if (Input.GetKey("d"))
            {
                MoveToRight();
            }

            if (Input.GetKey("a"))
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
            _currentForwardForce *= speedMultiplier;
            SideForce *= speedMultiplier;
        }
    }

}