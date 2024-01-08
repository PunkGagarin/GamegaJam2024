using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private Slider _slider;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    private void ChangeMasterVolume(float sliderValue)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", sliderValue);
    }
}
