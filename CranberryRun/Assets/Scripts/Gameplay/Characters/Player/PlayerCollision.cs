using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Player
{

    public class PlayerCollision : MonoBehaviour
    {

        private const string ObstacleTag = "Obstacle";
        private const string BonusTag = "Bonus";
        private const string UndergroundTag = "Underground";

        private WwiseEventHandler _wwiseEventHandler;

        [Inject] private PlayerMovement _movement;
        [Inject] private ScoreController _scoreController;
        [Inject] private GameManager _gameManager;

        public Action OnObstacleHit = delegate { };

        [SerializeField]
        private AK.Wwise.Event _bonusEvent;

        private void Awake()
        {
            _wwiseEventHandler = GetComponent<WwiseEventHandler>();
        }

        public void OnCollisionEnter(Collision other)
        {
            if (_gameManager.IsGameStopped) return;
            if (other.collider.CompareTag(ObstacleTag))
            {
                StopMoving();
                _wwiseEventHandler.PostEvent();
            }

            if (other.collider.CompareTag(UndergroundTag))
            {
                StopMoving();
            }
        }

        private void StopMoving()
        {
            _movement.StopMovement();
            OnObstacleHit.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (_gameManager.IsGameStopped) return;
            if (other.CompareTag(BonusTag))
            {
                _scoreController.AddBonusScore();
                _bonusEvent.Post(gameObject);
                var bonus = other.gameObject.GetComponent<ItemPackBonus>();
                bonus.TurnOffPrefab();
            }
        }

        public void Update()
        {
            if (_movement.transform.position.y <= -2)
            {
                StopMoving();
            }
        }
    }

}