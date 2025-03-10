using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Enemy _enemy;

    [SerializeField] private float _derectionRandomX = 0;
    [SerializeField] private float _derectionRandomZ = 0.1f;

    private int _spawnDelay = 2;
    private int _countAllPlayer = 10;
    private int _countPlayer;

    private Vector3 _direction;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_countPlayer < _countAllPlayer)
        {
            Transform randomIndexSpawn = ChooseRandomNumber();
            WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

            _direction = new Vector3(_derectionRandomX, 0, _derectionRandomZ);

            Enemy enemy = Instantiate(_enemy);

            enemy.transform.position = randomIndexSpawn.transform.position;
            enemy.transform.rotation = Quaternion.identity;

            _countPlayer++;

            enemy.Init(_direction);

            yield return wait;
        }
    }

    private Transform ChooseRandomNumber()
    {
        Transform spawnObject;

        int randomIndex = Random.Range(0, _spawnPoint.Length);

        spawnObject = _spawnPoint[randomIndex];

        return spawnObject;
    }
}
