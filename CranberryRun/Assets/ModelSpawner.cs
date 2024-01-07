using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModelSpawner : MonoBehaviour
{

    private float _startPointZ;
    private float _endPointZ;

    private float _distance;

    [SerializeField]
    private GameObject _startPoint;

    [SerializeField]
    private GameObject _endPoint;

    [SerializeField]
    private List<GameObject> _modelsToSpawn;


    private void Start()
    {
        _startPointZ = _startPoint.transform.position.z;
        _endPointZ = _endPoint.transform.position.z;
        _distance = _endPointZ - _startPointZ;

        var step = _distance / 2f;

        var tmpList = new List<GameObject>(_modelsToSpawn);

        var currentPoint = _startPointZ;

        for (int i = 0; i < step; i++)
        {
            var pickUpModel = tmpList[Random.Range(0, tmpList.Count)];
            Vector3 pointToInstantiate = new Vector3(_startPoint.transform.position.x, _startPoint.transform.position.y,
                currentPoint);

            Instantiate(pickUpModel, pointToInstantiate, Quaternion.identity);
            currentPoint += 2f;
        }
    }
}