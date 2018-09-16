using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private Vector2 _spawnPosition;
    public GameObject EnemyPrefab;
    public GameObject EnemyPrefab2;

    public int XPosition;
    [SerializeField] private float _minimumY;
    [SerializeField] private float _maximumY;

    public float EnemySpawnDelay = 2;
    public CompositeDisposable SpawnerDisposable = new CompositeDisposable();


    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        SpawnerDisposable = new CompositeDisposable();
        RestartSpawnerObservable();
    }

    public void SpawnEnemy()
    {
        _spawnPosition = new Vector2(XPosition, Random.Range(_minimumY, _maximumY));
        var rnd = Random.Range(0, 2);

        Instantiate(rnd == 0 ? EnemyPrefab : EnemyPrefab2, _spawnPosition, Quaternion.identity);
    }

    public void RestartSpawnerObservable()
    {
        if (SpawnerDisposable.Count > 0)
        {
            SpawnerDisposable.Dispose();
        }
        Observable.Interval(TimeSpan.FromSeconds(EnemySpawnDelay)).Subscribe(_ => SpawnEnemy()).AddTo(SpawnerDisposable)
            .AddTo(gameObject);

    }
}