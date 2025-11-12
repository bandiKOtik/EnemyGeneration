using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 5f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
