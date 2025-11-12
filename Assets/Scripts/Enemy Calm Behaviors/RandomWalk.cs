using UnityEngine;

public class RandomWalk : ICalmBehave
{
    [SerializeField] private float _minChangeTargetDistance = 0.1f;
    [Header("Borders"), SerializeField]
    private float _minX = -24, _maxX = 24, _minZ = -24, _maxZ = 24;

    void ICalmBehave.CalmBehave()
    {

    }

    private void GenerateRandomTarget()
    {

    }
}