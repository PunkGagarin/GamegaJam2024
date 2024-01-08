using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private Sprite _muteSprite;

    [SerializeField]
    private Sprite _lowHalfSprite;

    [SerializeField]
    private Sprite _highHalfSprite;

    [SerializeField]
    private Image _sliderImage;

    [SerializeField]
    private Slider _slider;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    private void ChangeMasterVolume(float sliderValue)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", sliderValue);
        _sliderImage.sprite = sliderValue switch
        {
            <= 0 => _muteSprite,
            <= 0.5f => _lowHalfSprite,
            _ => _highHalfSprite
        };
    }
}