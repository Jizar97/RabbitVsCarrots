using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 10;
    [SerializeField]
    private Canvas aimCanvas;
    [SerializeField]
    private Canvas TPCanvas;

    //pinto
    
    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    private void Awake() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable() {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable() {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim() {
        virtualCamera.Priority += priorityBoostAmount;
        aimCanvas.enabled = true;
        TPCanvas.enabled = false;

    }

    private void CancelAim() {
        virtualCamera.Priority -= priorityBoostAmount;
        aimCanvas.enabled = false;
        TPCanvas.enabled = true;
    }
}
