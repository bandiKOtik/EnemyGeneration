using UnityEngine;

public class Partol : ICalmBehave
{
    [SerializeField] private float _minChangeTargetDistance = 0.1f;
    [SerializeField] private Transform[] _patrolTargets;

    Transform _patrolTransform; //? Rename it idk

    public Partol(Transform patrolTransform)
    {
        _patrolTransform = patrolTransform;
    }

    void ICalmBehave.CalmBehave()
    {
        Transform currentTarget = _patrolTargets[0];

        foreach (Transform target in _patrolTargets)
        {
            Vector3 direction = GetDirection(target);

            //TODO: Дописать поиск
        }
    }

    private Vector3 GetDirection(Transform target) => target.position - _patrolTransform.position;
}
