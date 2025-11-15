using System.Collections.Generic;
using UnityEngine;

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
    int _targetIndex = 0;
    private List<Vector3> _patrolTargets;
    public Patrol(List<Vector3> targets) => _patrolTargets = targets;

    Vector3 IBehave.GetNewTargetPosition()
    {
        Vector3 newTarget = Vector3.zero;

        if (_targetIndex >= _patrolTargets.Count)
            _targetIndex = 0;

        newTarget = _patrolTargets[_targetIndex];

        _targetIndex++;

        return newTarget;
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
    private ParticleSystem _particles;
    //public Explode(ParticleSystem particle) => _particles = particle;

    Vector3 IBehave.GetNewTargetPosition()
    {
        DestroyObject();

        return Vector3.zero;
    }

    private void DestroyObject()
    {

    }
}