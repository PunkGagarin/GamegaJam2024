using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseWinLose : MonoBehaviour
{
       [SerializeField]
        private AK.Wwise.Event _winEvent;
             [SerializeField]
        private AK.Wwise.Event _loseEvent;

        public void PostWinEvent()
        {
            _winEvent.Post(gameObject);
        }
                public void PostLoseEvent()
        {
            _loseEvent.Post(gameObject);
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
