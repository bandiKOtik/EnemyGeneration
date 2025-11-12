using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [SerializeField] private Light[] eyesLight;
    [SerializeField] private GameObject body;

    [SerializeField] private Material calmMaterial;
    [SerializeField] private Material angryMaterial;

    private bool _isAngry;

    public void ChangeEnemyState(bool isAngry) => _isAngry = isAngry;
}
