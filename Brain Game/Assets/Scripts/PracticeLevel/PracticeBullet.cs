using UnityEngine;

public class PracticeBullet : MonoBehaviour
{
    public int bulletValue = 1; // Set this value when instantiating the bullet

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            //Debug.Log("Bullet hit crate with value: " + bulletValue); // Log bullet value

            PracticeCrateFall crate = other.GetComponent<PracticeCrateFall>();
            if (crate != null)
            {
                crate.SubtractValue(bulletValue); // Pass bullet's value to crate
            }

            Destroy(gameObject); // Destroy the bullet after it hits the crate
        }
    }

}
