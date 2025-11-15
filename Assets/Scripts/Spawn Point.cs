using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    private Enemy spawnedEnemy = null;

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
        spawnedEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        SetBehavior();

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
                List<Vector3> targetVectors = new List<Vector3>();

                foreach (Transform target in _patrolTargets)
                    targetVectors.Add(target.position);

                _idleBehave = new Patrol(targetVectors);
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
                _reactionBehave = new RunAway(spawnedEnemy.PlayerDetectPosition, spawnedEnemy.transform.position);
                break;

            case ReactionBehavior.MoveToTarget:
                _reactionBehave = new MoveToTarget(spawnedEnemy);
                break;

            case ReactionBehavior.Explode:
                _reactionBehave = new Explode(spawnedEnemy);
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for AngerBehavior!");
                break;
        }
    }
}
