using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ICalmBehave _calmBehavior;
    [SerializeField] private IAngerBehave _angerBehavior;

    [SerializeField] private Transform[] _patrolTargets;

    //void ICalmBehave.CalmBehave(CalmBehavior behavior)
    //{
    //    switch (behavior)
    //    {
    //        case CalmBehavior.Stay:
    //            break;

    //        case CalmBehavior.Patrol:
    //            if (_patrolTargets != null)
    //                Patrol();
    //            break;

    //        case CalmBehavior.RandomWalk:
    //            RandomWalk();
    //            break;

    //        default:
    //            Debug.LogError($"{gameObject.name}: There is no such realisation for CalmBehavior!");
    //            break;
    //    }
    //}

    //private void Patrol()
    //{

    //}

    //private void RandomWalk()
    //{

    //}

    //void IAngerBehave.AngerBehave(AngerBehavior behavior)
    //{
    //    switch (behavior)
    //    {
    //        case AngerBehavior.RunAway:
    //            break;

    //        case AngerBehavior.TryHit:
    //            break;

    //        case AngerBehavior.Explode:
    //            break;

    //        default:
    //            Debug.LogError($"{gameObject.name}: There is no such realisation for AngerBehavior!");
    //            break;
    //    }
    //}

    //private void RunAwayFrom(Vector3 target)
    //{

    //}

    //private void MoveToTarget(Vector3 target)
    //{

    //}
}