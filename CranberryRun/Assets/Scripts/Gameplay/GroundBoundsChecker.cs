using UnityEngine;

public class GroundBoundsChecker : MonoBehaviour
{

    private float _size;
    public float LeftBorder { get; private set; }
    public float RightBorder { get; private set; }

    [SerializeField]
    private GameObject _ground;

    private void Awake()
    {
        _size = _ground.transform.localScale.x;
        LeftBorder = 0 - _size / 2;
        RightBorder = _size / 2;
    }

}
