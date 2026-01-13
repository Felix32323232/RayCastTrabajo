using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    public float rayDistance = 5f;      
    public LayerMask leverLayer;        

    private void Update()
    {
       
    }

    public void ShootRay()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, leverLayer))
        {
            Lever lever = hit.collider.GetComponent<Lever>();
            if (lever != null)
            {
                lever.Activate();
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.orange, 1f);
    }
}