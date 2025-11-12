using UnityEngine;

[RequireComponent(typeof(FirstPersonController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float startSpeed = 5f;
    [SerializeField] private float sprintSpeedAddition = 2f;

    FirstPersonController firstPersonController;

    private void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        ApplySpeedValues(firstPersonController);
    }

    private void ApplySpeedValues(FirstPersonController controller)
    {
        controller.walkSpeed = startSpeed;
        controller.sprintSpeed = startSpeed + sprintSpeedAddition;
    }
}
