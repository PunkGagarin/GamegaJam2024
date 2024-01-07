using UnityEngine;

public class LoseLevelUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _content;

    public void TurnOn()
    {
        _content.gameObject.SetActive(true);
    }
    
    public void TurnOff()
    {
        _content.gameObject.SetActive(false);
    }
}
