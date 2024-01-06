using UnityEngine;

namespace Gameplay.Player
{

    public class PlayerMovement : MonoBehaviour
    {

        private Rigidbody _rigidbody;

        private bool _isMoving = true;


        [field: SerializeField]
        public float ForwardForce { get; private set; } = 100f;

        [field: SerializeField]
        public float SideForce { get; private set; } = 25;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            if (!_isMoving) return;

            _rigidbody.AddForce(0, 0, ForwardForce * Time.fixedDeltaTime);

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
            ForwardForce *= speedMultiplier;
            SideForce *= speedMultiplier;
        }
    }

}