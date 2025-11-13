using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private void Start()
    {
        if (_enemyPrefab != null)
            InstantiateSpawnableItem();
    }

    public void InstantiateSpawnableItem()
        => _enemyPrefab = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
}
