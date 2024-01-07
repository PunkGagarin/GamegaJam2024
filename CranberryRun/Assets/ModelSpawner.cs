using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModelSpawner : MonoBehaviour
{

    private float _startPointZ;
    private float _endPointZ;
    private float _startPointX;
    private float _endPointX;

    private float _Zdistance;
    private float _Xdistance;

    [SerializeField]
    private GameObject _startPoint;

    [SerializeField]
    private GameObject _endPoint;

    [SerializeField]
    private List<GameObject> _modelsToSpawn;


    private void Start()
    {
        _startPointZ = _startPoint.transform.position.z;
        _startPointX = _startPoint.transform.position.x;
        _endPointZ = _endPoint.transform.position.z;
        _endPointX = _endPoint.transform.position.x;
        _Zdistance = _endPointZ - _startPointZ;
        _Xdistance = _endPointX - _startPointX;


        int zSteps = (int)_Zdistance / 2;
        int xSteps = (int)_Xdistance / 2;

        var tmpList = new List<GameObject>(_modelsToSpawn);

        var currentPointZ = _startPointZ;
        var currentPointX = _startPointX;

        for (int i = 0; i < zSteps; i++)
        {
            for (int j = 0; j < xSteps; j++)
            {
                var pickUpModel = tmpList[Random.Range(0, tmpList.Count)];
                Vector3 pointToInstantiate = new Vector3(currentPointX,
                    _startPoint.transform.position.y,
                    currentPointZ);

                Instantiate(pickUpModel, pointToInstantiate, Quaternion.identity);
                currentPointX += 2f;
            }
            currentPointZ += 2f;
            currentPointX = _startPointX;
        }
    }
}