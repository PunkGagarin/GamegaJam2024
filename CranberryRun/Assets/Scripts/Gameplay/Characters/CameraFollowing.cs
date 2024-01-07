using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{

    public class CameraFollowing : MonoBehaviour
    {


        [Inject] private PlayerCharacter _character;

        [SerializeField]
        private Vector3 _followOffset;

        private void LateUpdate()
        {
            transform.position = _character.transform.position + _followOffset;
        }
    }

}