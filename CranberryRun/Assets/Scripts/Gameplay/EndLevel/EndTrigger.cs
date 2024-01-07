using System;
using UnityEngine;

namespace Gameplay.EndLevel
{

    public class EndTrigger : MonoBehaviour
    {

        public Action OnEndTriggerPassed = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            OnEndTriggerPassed.Invoke();
        }
    }

}