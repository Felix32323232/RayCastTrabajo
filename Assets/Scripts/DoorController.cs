using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Lever[] levers;       
    public float openAngle = 90f; 
    public float openSpeed = 2f;  

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0); 
    }

    private void Update()
    {
        if (!isOpen && AllLeversActive())
        {
            isOpen = true;
           
        }

       
        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
    }

    private bool AllLeversActive()
    {
        foreach (Lever lever in levers)
        {
            if (!lever.IsActive())
                return false;
        }
        return true;
    }
}