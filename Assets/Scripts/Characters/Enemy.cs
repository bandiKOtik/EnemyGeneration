using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private ParticleSystem _deathParticles;
    public ParticleSystem DeathEffectParticles { get => _deathParticles; }
    public Vector3 PlayerDetectPosition { get; set; }

    [SerializeField] private float _minTargetDistance = 0.1f;
    private Vector3 _currentTarget;

    private bool _isReactionActive = false;
    public IBehave IdleBehave { get; private set; }
    public IBehave ReactionBehave { get; private set; }
    public void Initialize(IBehave idle, IBehave reaction)
    {
        IdleBehave = idle;
        ReactionBehave = reaction;
    }

    private void Start()
    {
        gameObject.SetActive(true);
        _currentTarget = IdleBehave.GetNewTargetPosition();
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

    private void SelectTarget()
    {
        Vector3 direction = GetDirectionTo(_currentTarget);

        if (_isReactionActive == false)
        {
            if (direction.magnitude <= _minTargetDistance)
                _currentTarget = IdleBehave.GetNewTargetPosition();
        }
        else
        {
            _currentTarget = ReactionBehave.GetNewTargetPosition();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isReactionActive = true;
            PlayerDetectPosition = other.transform.position;
            Debug.Log(PlayerDetectPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _isReactionActive = false;
    }
}