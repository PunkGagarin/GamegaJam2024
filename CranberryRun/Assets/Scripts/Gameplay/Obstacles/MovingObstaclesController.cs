using System.Collections.Generic;
using Gameplay.Obstacles;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{

    public class MovingObstaclesController : MonoBehaviour
    {

        [Inject] private GroundBoundsChecker _boundsChecker;

        private List<MovingObstacle> _movingObstacles = new();

        public void RegisterObstacle(MovingObstacle movingObstacle)
        {
            _movingObstacles.Add(movingObstacle);
            movingObstacle.Init(_boundsChecker.LeftBorder, _boundsChecker.RightBorder);
        }
    }

}