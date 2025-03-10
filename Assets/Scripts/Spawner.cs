using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _pollCount;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private bool _autoExpand = false;

    [SerializeField] private float _derectionRandomX = 0;
    [SerializeField] private float _derectionRandomZ = 0.1f;

    private int _spawnDelay = 2;

    private Vector3 _direction;

    private Poll<Enemy> _poll;

    private void Awake()
    {
        _poll = new Poll<Enemy>(_enemy, _pollCount, transform);
        _poll._autoExpand = _autoExpand;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnDelay);
            CreateEnemy();

            yield return wait;
        }
    }

    private void CreateEnemy()
    {
        Transform randomIndexSpawn = ChooseRandomNumber();
        _direction = new Vector3(_derectionRandomX, 0, _derectionRandomZ);

        Enemy enemy = _poll.GetFreeElement();

        enemy.transform.position = randomIndexSpawn.transform.position;
        enemy.transform.rotation = Quaternion.identity;
        enemy.Init(_direction);
    }

    private Transform ChooseRandomNumber()
    {
        Transform spawnObject;

        int randomIndex = Random.Range(0, _spawnPoint.Length);

        spawnObject = _spawnPoint[randomIndex];

        return spawnObject;
    }
}