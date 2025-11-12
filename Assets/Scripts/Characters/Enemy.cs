using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Transform[] _targers;

    [SerializeField] private float _minTargetDistance = 0.1f;
    [SerializeField] private Transform _currentTarget;

    private void Update()
    {
        Vector3 direction = GetDirectionTo();

        if (direction.magnitude <= _minTargetDistance)
            return;

        Vector3 normalizedDirection = direction.normalized;

        ProcessMove(normalizedDirection);

        ProcessRotation(normalizedDirection);
    }

    private Vector3 GetDirectionTo() => _currentTarget.position - transform.position;

    private void ProcessMove(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void ProcessRotation(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
    }

    public void SelectTarget()
    {

    }
}