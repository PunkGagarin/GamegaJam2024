using UnityEngine;

public class TransformRotator : MonoBehaviour
{
    [SerializeField]
    private float _degreesPerSecond = 20;
    
    public void Update()
    {
        transform.Rotate(new Vector3(0, _degreesPerSecond, 0) * Time.deltaTime);
    }
}
