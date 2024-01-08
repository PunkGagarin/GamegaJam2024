using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseWinLose : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event _winEvent;

    [SerializeField]
    private AK.Wwise.Event _loseEvent;

    public void PlayWinSound()
    {
        _winEvent.Post(gameObject);
    }

    public void PlayLoseSound()
    {
        _loseEvent.Post(gameObject);
    }
}