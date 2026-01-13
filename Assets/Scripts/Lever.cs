using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isActive = false;

    public float rotationAngle = 45f; 
    public float rotationSpeed = 5f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
    }

    private void Update()
    {
        
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void Activate()
    {
        if (!isActive)
        {
            isActive = true;
           
            targetRotation = initialRotation * Quaternion.Euler(-rotationAngle, 0, 0);
           
        }
    }

   
    public bool IsActive()
    {
        return isActive;
    }
}