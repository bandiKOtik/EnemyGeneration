using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private IdleBehavior _idleBehaviorType;
    [SerializeField] private ReactionBehavior _reactionBehaviorType;

    [SerializeField] private Transform[] _patrolTargets;

    private IBehave _idleBehave;
    private IBehave _reactionBehave;

    private void Awake()
    {
        if (_enemyPrefab != null)
            InstantiateSpawnableItem();
    }

    public void InstantiateSpawnableItem()
    {
        SetBehavior();

        Enemy spawnedEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (_patrolTargets.Length == 0 && _idleBehaviorType == IdleBehavior.Patrol)
        {
            Debug.Log($"{spawnedEnemy.name} patrol transforms not attached!");
            _idleBehave = new RandomWalk();
        }

        spawnedEnemy.Initialize(_idleBehave, _reactionBehave);
    }

    private void SetBehavior()
    {
        switch (_idleBehaviorType)
        {
            case IdleBehavior.Stay:
                _idleBehave = new Stay(transform.position);
                break;

            case IdleBehavior.Patrol:
                _idleBehave = new Patrol();
                break;

            case IdleBehavior.RandomWalk:
                _idleBehave = new RandomWalk();
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for CalmBehavior!");
                break;
        }

        switch (_reactionBehaviorType)
        {
            case ReactionBehavior.RunAway:
                _reactionBehave = new RunAway();
                break;

            case ReactionBehavior.MoveToTarget:
                _reactionBehave = new MoveToTarget();
                break;

            case ReactionBehavior.Explode:
                _reactionBehave = new Explode();
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for AngerBehavior!");
                break;
        }
    }
}
