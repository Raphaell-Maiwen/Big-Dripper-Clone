using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HoneyManager : MonoBehaviour
{
    public static HoneyManager Instance { get; private set; }

    [SerializeField] private Honeycomb[] _honeycombs;
    [SerializeField] private HoneyPuddle[] _honeyPuddles;
    [SerializeField] private List<HoneyDrop> _honeyDrops;

    [SerializeField] private Transform _honeyDropsPoolAnchor;

    [SerializeField] private float minimumIntervalTime;
    [SerializeField] private float maximumIntervalTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        { 
            Destroy(gameObject);
        }
    }

    public void Start() 
    {
        StartCoroutine(SpawnHoneyCoroutine(0f));
    }

    IEnumerator SpawnHoneyCoroutine(float time) 
    {
        yield return new WaitForSeconds(time);
        Debug.Log(time);

        SpawnHoneyDrop();
        StartCoroutine(SpawnHoneyCoroutine(Random.Range(minimumIntervalTime, maximumIntervalTime)));
    }

    private void SpawnHoneyDrop()
    {
        if (_honeyDrops.Count <= 0) return;

        var honeyDrop = _honeyDrops[0];

        var availableHoneycombs = _honeycombs.Where(h => h.ReadyToDrop).ToList();
        Honeycomb honeycomb = availableHoneycombs[Random.Range(0, availableHoneycombs.Count)];
        honeycomb.OnDropSpawned();

        honeyDrop.transform.position = honeycomb.transform.position;
        _honeyDrops.RemoveAt(0);
        honeyDrop.StartGravity();
    }

    public void PutDropBackInQueue(HoneyDrop honeyDrop) 
    {
        _honeyDrops.Add(honeyDrop);
        honeyDrop.gameObject.transform.position = _honeyDropsPoolAnchor.transform.position;
        honeyDrop.StopGravity();
    }
}