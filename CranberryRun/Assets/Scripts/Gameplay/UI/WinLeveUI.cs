using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinLeveUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _content;

    [field: SerializeField]
    public Button NextLevelButton { get; private set; }

    [field: SerializeField]
    public Button MenuButton { get; private set; }

    public void TurnOn()
    {
        _content.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        _content.gameObject.SetActive(false);
    }
}