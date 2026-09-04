using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private InteractionPromptUI promptUI;

    private InputAction interactAction;
    private IInteractable currentTarget;
    private void Awake()
    {
        if(InputSystem.actions!= null)
        {
            interactAction = InputSystem.actions.FindAction("Interact");
        }
        if (interactAction == null)
        {
            Debug.LogError("Interact action not found in Input System.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        FindTarget();

        if (currentTarget != null && currentTarget.CanInteract && interactAction != null && interactAction.WasPressedThisFrame())
        {
            currentTarget.Interact(gameObject);
        }
    }


    private void FindTarget()
    {
        currentTarget = null;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactMask))
        {
            currentTarget = hit.collider.GetComponentInParent<IInteractable>(); 
        }

        if(promptUI != null)
        {
            if (currentTarget != null && currentTarget.CanInteract)
            {
                promptUI.Show(currentTarget.Prompt + "- E");
            }
            else
            {
                promptUI.Hide();
            }
        }   
    
    
    }
}
