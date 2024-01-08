using UnityEngine;

namespace Gameplay
{

    public class WwiseEventHandler : MonoBehaviour
    {
        [SerializeField]
        private AK.Wwise.Event _event;

        public void PostEvent()
        {
            _event.Post(gameObject);
        }

    }

}