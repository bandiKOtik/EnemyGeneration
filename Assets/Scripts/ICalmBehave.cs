using UnityEngine;

public interface ICalmBehave
{
    public abstract Vector3 GetNewTargetPosition();
}

public class RandomWalk : ICalmBehave
{
    private float _minX = -24, _maxX = 24, _minZ = -24, _maxZ = 24;

    Vector3 ICalmBehave.GetNewTargetPosition()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomZ = Random.Range(_minZ, _maxZ);

        return new Vector3(randomX, 0, randomZ);
    }
}

public class Patrol : ICalmBehave
{
    [SerializeField] private Transform[] _patrolTargets;

    Vector3 ICalmBehave.GetNewTargetPosition()
    {
        Transform currentTarget = _patrolTargets[0];
        // Позже будут условия
        return Vector3.zero;
    }
}
