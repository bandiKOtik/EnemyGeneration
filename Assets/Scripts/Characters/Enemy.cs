using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private CalmBehavior _calmBehavior;
    [SerializeField] private AngerBehavior _angerBehavior;
    private ICalmBehave _calmBehave;
    private IAngerBehave _angerBehave;

    [SerializeField] private Transform[] _targers;

    [SerializeField] private float _minTargetDistance = 0.1f;
    [SerializeField] private Vector3 _currentTarget;

    private void Awake()
    {
        SetBehavior();

        _calmBehave.GetNewTargetPosition();
    }

    private void Update()
    {
        SelectTarget();

        Vector3 direction = GetDirectionTo(_currentTarget);
        Vector3 normalizedDirection = direction.normalized;

        ProcessMove(normalizedDirection);
        ProcessRotation(normalizedDirection);
    }

    private Vector3 GetDirectionTo(Vector3 target) => target - transform.position;

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

    private void SetBehavior()
    {
        switch (_calmBehavior)
        {
            case CalmBehavior.Stay:
                _currentTarget = transform.position;
                break;

            case CalmBehavior.Patrol:
                _calmBehave = new Patrol();
                break;

            case CalmBehavior.RandomWalk:
                _calmBehave = new RandomWalk();
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for CalmBehavior!");
                break;
        }

        switch (_angerBehavior)
        {
            case AngerBehavior.RunAway:
                _angerBehave = new RunAway();
                break;

            case AngerBehavior.MoveToTarget:
                _angerBehave = new MoveToTarget();
                break;

            case AngerBehavior.Explode:
                _angerBehave = new Explode();
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for AngerBehavior!");
                break;
        }
    }

    private void SelectTarget()
    {
        Vector3 direction = GetDirectionTo(_currentTarget);

        if (direction.magnitude <= _minTargetDistance)
            _currentTarget = _calmBehave.GetNewTargetPosition();
    }

    private void OnTriggerStay(Collider other)
    {
        float radius = 25f;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Player")
            {
                Debug.Log("Collider detected: " + collider.name);
                // Логика после детекта игрока
            }
        }
    }
}