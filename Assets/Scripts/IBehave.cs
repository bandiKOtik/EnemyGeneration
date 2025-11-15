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
    private Vector3 _runAwayFrom;
    private Vector3 _objectPosition;
    public RunAway(Vector3 runFrom, Vector3 objectPosition)
    {
        _runAwayFrom = runFrom;
        _objectPosition = objectPosition;
    }
    Vector3 IBehave.GetNewTargetPosition()
    {
        return _objectPosition + (_objectPosition - _runAwayFrom);
    }
}

public class MoveToTarget : IBehave
{
    Enemy _enemy;
    public MoveToTarget(Enemy enemy)
    {
        _enemy = enemy;
    }
    Vector3 IBehave.GetNewTargetPosition()
    {
        return _enemy.PlayerDetectPosition;
    }
}

public class Explode : IBehave
{
    private Enemy _exploderObject;
    private ParticleSystem _particles;
    public Explode(Enemy enemyPrefab)
    {
        _exploderObject = enemyPrefab;
    }

    Vector3 IBehave.GetNewTargetPosition()
    {
        KillObject();

        return Vector3.zero;
    }

    private void KillObject()
    {
        if (_exploderObject.DeathEffectParticles != null)
            Object.Instantiate(_particles.gameObject, _exploderObject.transform.position, Quaternion.identity);

        Object.Destroy(_exploderObject.gameObject);
    }
}