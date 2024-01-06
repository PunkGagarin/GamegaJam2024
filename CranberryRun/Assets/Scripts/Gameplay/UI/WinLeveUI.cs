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

    // public UnityAction OnNextLevelPressed = delegate { };
    // public UnityAction OnMenuButtonPressed = delegate { };

    private void Awake()
    {
        // _nextLevelButton.onClick.AddListener(OnNextLevelPressed);
        // _menuButton.onClick.AddListener(OnMenuButtonPressed);
    }

    private void OnDestroy()
    {
        // _nextLevelButton.onClick.RemoveListener(OnNextLevelPressed);
        // _menuButton.onClick.RemoveListener(OnMenuButtonPressed);
    }

    public void TurnOn()
    {
        _content.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        _content.gameObject.SetActive(false);
    }
}