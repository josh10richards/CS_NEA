using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isLocked = false;
    [SerializeField] private float openAngle = 105f;
    [SerializeField] private float openSpeed = 180f;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Coroutine swingRoutine;

    private float currentAngle;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool CanInteract => swingRoutine == null;
    public string Prompt => isOpen ? "Close" : "Open";


    private void Awake()
    {
        closedRotation = transform.localRotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Swing(float targetAngle)
    {
        while (!Mathf.Approximately(currentAngle, targetAngle))
        {
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, openSpeed * Time.deltaTime);
            transform.localRotation = closedRotation * Quaternion.Euler(0f, currentAngle, 0f);
            yield return null;
        }
        swingRoutine = null;
    }

    public void Interact(GameObject interactor)
    {
        if (isLocked) return;
        float target = 0f;
        if (!isOpen)
        {
            float direction = 1f;
            if(interactor != null)
            {
                Vector3 toPlayer = interactor.transform.position-transform.position;
                direction = Vector3.Dot(transform.forward, toPlayer) > 0f ? -1f: 1f;
            }
            target = openAngle*direction;

        }

        isOpen = !isOpen;
        if (swingRoutine != null) StopCoroutine(swingRoutine);
        swingRoutine = StartCoroutine(Swing(target));
    }




}




