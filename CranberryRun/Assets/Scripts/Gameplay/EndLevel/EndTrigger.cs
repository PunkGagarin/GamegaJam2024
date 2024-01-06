using System;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public Action OnEndTriggerPassed = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        OnEndTriggerPassed.Invoke();
    }
}