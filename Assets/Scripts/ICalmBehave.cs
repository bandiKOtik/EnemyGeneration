using UnityEngine;

public interface ICalmBehave
{
    public abstract Vector3 GetNewTargetPosition();
}

public class Stay : ICalmBehave
{
    private Transform characterTransform;
    public Stay(Transform transform) => characterTransform = transform;
    Vector3 ICalmBehave.GetNewTargetPosition()
    {
        return characterTransform.position;
    }
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
    private Vector3[] _patrolTargets = new Vector3[]
    {
        new Vector3(20, 0, 20),
        new Vector3(20, 0, -20),
        new Vector3(-20, 0, -20),
        new Vector3(-20, 0, 20)
    };

    Vector3 ICalmBehave.GetNewTargetPosition()
    {
        Vector3 newMainTarget = Vector3.zero;

        for (int i = 0; i < _patrolTargets.Length; i++)
        {
            newMainTarget = _patrolTargets[i];
        }

        return newMainTarget;
    }
}
