using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInteraction: MonoBehaviour {

    public float interactionDistance;

    //public TMPro.TextMeshProUGUI interactionText;
    public Text interactionText;
    //public GameObject interactionHoldGO; // the ui parent to disable when not interacting
    //public UnityEngine.UI.Image interactionHoldProgress; // the progress bar for hold interaction type

    private PlayerInput playerInput;

    Camera cam;

    private InputAction interactAction;

    void Start() {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
        interactAction = playerInput.actions["Interact"];
    }

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) {
            Interactable interactable = hit.collider.GetComponent < Interactable > ();

            if (interactable != null) {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;

                //interactionHoldGO.SetActive(interactable.interactionType == Interactable.InteractionType.Hold);
            }
        }

        // if we miss, hide the UI
        if (!successfulHit) {
            //Debug.Log ("Ovo escodner a UI");
            interactionText.text = "";
            //interactionHoldGO.SetActive(false);
        }
    }

    void HandleInteraction(Interactable interactable) {
        //KeyCode key = KeyCode.E;
        switch (interactable.interactionType) {
            case Interactable.InteractionType.Click:
                // interaction type is click and we clicked the button -> interact
                if (interactAction.triggered) {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (interactAction.triggered) {
                    interactable.Interact();
                }         
                break;
                // here is started code for your custom interaction :)
            case Interactable.InteractionType.Minigame:
                // here you make ur minigame appear
                break;

                // helpful error for us in the future
            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}