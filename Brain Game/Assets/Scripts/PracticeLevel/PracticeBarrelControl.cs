using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PracticeBarrelControl : MonoBehaviour
{
    float angle = 0f;

    [Header("Inscribed")]
    public GameObject projectilePrefab;
    public Transform barrelEnd; // Assign the end of the barrel in the Unity Editor
    public float projectileSpeed = 40;

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle - 90) < 85)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TempFire();
        //}

        // Check if the game is paused before allowing shooting
        if (PauseGame.isPaused)
        {
            return; // Exit the Update method without shooting if the game is paused
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            TempFire(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            TempFire(2);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            TempFire(3);
        }
    }

    void TempFire(int bulletValue)
    {
        // Instantiate the projectile at the barrel end position and orientation
        GameObject projGO = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation);

        // Set the projectile's velocity
        Rigidbody rigidRB = projGO.GetComponent<Rigidbody>();
        rigidRB.velocity = barrelEnd.up * projectileSpeed;

        PracticeBullet bullet = projGO.GetComponent<PracticeBullet>();
        if (bullet != null)
        {
            bullet.bulletValue = bulletValue;
        }

        // Set the bullet's text to the appropriate value
        TextMeshPro textComponent = projGO.GetComponentInChildren<TextMeshPro>();
        if (textComponent != null)
        {
            textComponent.text = bulletValue.ToString();
        }
    }
}
