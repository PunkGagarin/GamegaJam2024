using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemPackBonus : MonoBehaviour
{
    private GameObject _choosenPrefab;

    [SerializeField]
    private List<GameObject> _prefabs;

    private void Awake()
    {
        Assert.IsNotEmpty(_prefabs);
        _choosenPrefab = _prefabs[Random.Range(0, _prefabs.Count)];
        _choosenPrefab.gameObject.SetActive(true);
    }

    public void TurnOffPrefab()
    {
        _choosenPrefab.gameObject.SetActive(false);
    }
}