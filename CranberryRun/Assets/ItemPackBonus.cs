using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemPackBonus : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _prefabs;

    private void Awake()
    {
        Assert.IsNotEmpty(_prefabs);
        var randomGo = _prefabs[Random.Range(0, _prefabs.Count)];
        randomGo.gameObject.SetActive(true);
    }
}
