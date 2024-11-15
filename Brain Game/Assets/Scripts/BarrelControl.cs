using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrelControl : MonoBehaviour
{
    float angle = 0f;

    [Header("Inscribed")]
    public GameObject projectilePrefab;
    public Transform barrelEnd; // Assign the end of the barrel in the Unity Editor
    public float projectileSpeed = 40;
    public TextMeshProUGUI ball1;
    public TextMeshProUGUI ball2;
    public TextMeshProUGUI ball3;

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
            int currentValue = int.Parse(ball1.text);
            if (currentValue > 0)
            {
                ball1.text = (currentValue - 1).ToString();
                TempFire(1);
            }            
            else { return; }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            int currentValue = int.Parse(ball2.text);
            if (currentValue > 0)
            {
                ball2.text = (currentValue - 1).ToString();
                TempFire(2);
            }
            else { return; }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            int currentValue = int.Parse(ball3.text);
            if (currentValue > 0)
            {
                ball3.text = (currentValue - 1).ToString();
                TempFire(3);
            }
            else { return; }
        }
    }

    void TempFire(int bulletValue)
    {
        // Instantiate the projectile at the barrel end position and orientation
        GameObject projGO = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation);

        // Set the projectile's velocity
        Rigidbody rigidRB = projGO.GetComponent<Rigidbody>();
        rigidRB.velocity = barrelEnd.up * projectileSpeed;

        Bullet bullet = projGO.GetComponent<Bullet>();
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

    public void ResetAmmo()
    {
        ball1.text = 50.ToString();
        ball2.text = 50.ToString();
        ball3.text = 50.ToString();
    }
}
