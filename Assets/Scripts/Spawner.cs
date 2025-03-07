using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Transform _prefab;
    [SerializeField] private Enemy _enemy;

    private int _spawnDelay = 2;
    private int _countAllPlayer = 10;

    private int _countPlayer;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (_countPlayer < _countAllPlayer)
        {
            Transform randomIndexSpawn = ChooseRandomNumber();

            Instantiate(_prefab, randomIndexSpawn.transform.position, Quaternion.identity);

            _countPlayer++;

            _enemy.Move();

            yield return new WaitForSecondsRealtime(_spawnDelay);
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
