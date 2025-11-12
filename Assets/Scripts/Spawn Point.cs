using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private bool _holdForever = true;
    [SerializeField] private float _destroyTime = 10f;
    private float _timer = 0f;

    private Enemy _holdableItem;
    public bool IsBusy
    {
        get
        {
            if (_holdableItem != null)
                if (_holdableItem.GetComponent<Collider>() == null)
                    _holdableItem = null;

            if (_holdableItem == null)
                return false;

            return true;
        }
    }

    private void Awake() => _timer = _destroyTime;

    private void Update()
    {
        if (_holdForever == false)
            ProcessDestroyItemTimer();
    }

    public void InstantiateSpawnableItem(Enemy item)
        => _holdableItem = Instantiate(item, transform.position, Quaternion.identity);

    private void ProcessDestroyItemTimer()
    {
        if (_holdableItem != null)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                if (IsBusy)
                {
                    Destroy(_holdableItem.gameObject);
                    _holdableItem = null;
                }

                _timer = _destroyTime;
            }
        }
    }
}
