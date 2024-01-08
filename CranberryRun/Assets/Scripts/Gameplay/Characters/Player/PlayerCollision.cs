using System;
using Gameplay.Characters.Player;
using Gameplay.Player;
using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{

    private const string ObstacleTag = "Obstacle";
    private const string UndergroundTag = "Underground";

    [Inject] private PlayerMovement _movement;

    public Action OnObstacleHit = delegate { };

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(ObstacleTag) || other.collider.CompareTag(UndergroundTag))
        {
            _movement.StopMovement();
            OnObstacleHit.Invoke();
        }
    }

    public void Update()
    {
        if (_movement.transform.position.y <= -2)
        {
            _movement.StopMovement();
            OnObstacleHit.Invoke();
        }
    }
}