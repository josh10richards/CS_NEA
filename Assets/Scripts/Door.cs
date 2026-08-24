using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = false;
    public float openAngle = 105f;
    public float openSpeed = 2f;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedRotation = transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
