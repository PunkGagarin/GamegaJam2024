using UnityEngine;
using UnityEngine.UI;

public class RestartProgress : MonoBehaviour
{
    private Button _restartButton;

    private void Awake()
    {
        _restartButton = GetComponent<Button>();
        _restartButton.onClick.AddListener(RestartLevelProgress);
    }

    private void RestartLevelProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
