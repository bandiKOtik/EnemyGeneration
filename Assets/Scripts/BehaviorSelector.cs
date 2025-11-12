using UnityEngine;

public class BehaviorSelector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    [SerializeField] private CalmBehavior _calmBehavior;
    [SerializeField] private AngerBehavior _angerBehavior;

    //[SerializeField] private Transform[] _patrolTargets;

    private void Awake()
    {
        SetCalmBehavior();
        SetAngerBehavior();
    }

    private void SetCalmBehavior()
    {
        switch (_calmBehavior)
        {
            case CalmBehavior.Stay:
                break;

            case CalmBehavior.Patrol:
                break;

            case CalmBehavior.RandomWalk:
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for CalmBehavior!");
                break;
        }
    }

    private void SetAngerBehavior()
    {
        switch (_angerBehavior)
        {
            case AngerBehavior.RunAway:
                break;

            case AngerBehavior.TryHit:
                break;

            case AngerBehavior.Explode:
                break;

            default:
                Debug.LogError($"{gameObject.name}: There is no such realisation for AngerBehavior!");
                break;
        }
    }
}
