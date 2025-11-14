using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public interface IBehave
{
    public abstract Vector3 GetNewTargetPosition();
}

public class Stay : IBehave
{
    private Vector3 characterTransform;
    public Stay(Vector3 defaultPosition) => characterTransform = defaultPosition;
    Vector3 IBehave.GetNewTargetPosition()
    {
        return characterTransform;
    }
}

public class RandomWalk : IBehave
{
    private float _minX = -24, _maxX = 24, _minZ = -24, _maxZ = 24;

    Vector3 IBehave.GetNewTargetPosition()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomZ = Random.Range(_minZ, _maxZ);

        return new Vector3(randomX, 0, randomZ);
    }
}

public class Patrol : IBehave
{
    private Vector3[] _patrolTargets;
    //public Patrol(Vector3[] targets) => _patrolTargets = targets;

    Vector3 IBehave.GetNewTargetPosition()
    {
        Vector3 newMainTarget = Vector3.zero;

        for (int i = 0; i < _patrolTargets.Length; i++)
        {
            newMainTarget = _patrolTargets[i];
        }

        return newMainTarget;
    }
}
public class RunAway : IBehave
{
    Vector3 IBehave.GetNewTargetPosition()
    {
        return Vector3.zero;
    }
}

public class MoveToTarget : IBehave
{
    Vector3 _target;
    public void SetTarrget(Vector3 target) => _target = target;
    Vector3 IBehave.GetNewTargetPosition()
    {
        return _target.normalized;
    }
}

public class Explode : IBehave
{
    Vector3 IBehave.GetNewTargetPosition()
    {
        return Vector3.zero;
    }
}