using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Timer"), SerializeField] private bool _processTimer = true;
    [SerializeField] private float _timeBeforeNewItemSpawn = 5f;
    private float timer = 0f;

    [Header("Spawner"), SerializeField] private SpawnPoint[] spawnPoints;
    [SerializeField] private Enemy[] _enemyVariantPrefabs;

    private void Update()
    {
        if (_processTimer)
            ProcessTimer();
    }

    private void ProcessTimer()
    {
        if (timer <= 0)
        {
            SpawnNewItem(_enemyVariantPrefabs[Random.Range(0, _enemyVariantPrefabs.Length)]);
            timer = _timeBeforeNewItemSpawn;
            return;
        }

        timer -= Time.deltaTime;
    }

    private void SpawnNewItem(Enemy item)
    {
        Queue<SpawnPoint> spawnsQueue = ShuffledArray(spawnPoints);

        for (int i = 0; i < spawnsQueue.Count; i++)
        {
            SpawnPoint poit = spawnsQueue.Dequeue();
            if (poit.IsBusy == false)
            {
                poit.InstantiateSpawnableItem(item);
                break;
            }
        }
    }

    private Queue<SpawnPoint> ShuffledArray(SpawnPoint[] array)
    {
        SpawnPoint[] shuffledArray = (SpawnPoint[])array.Clone();

        for (int i = 0; i < shuffledArray.Length; i++)
        {
            int randomIndex = Random.Range(0, shuffledArray.Length);

            SpawnPoint temp = shuffledArray[i];
            shuffledArray[i] = shuffledArray[randomIndex];
            shuffledArray[randomIndex] = temp;
        }

        return new Queue<SpawnPoint>(shuffledArray);
    }
}
