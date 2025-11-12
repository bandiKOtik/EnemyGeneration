using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _worldRotateDirection;
    void Update()
    {
        gameObject.transform.Rotate(_worldRotateDirection * Time.deltaTime, Space.World);
    }
}
