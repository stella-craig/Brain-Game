using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 10f; // The movement speed is 10m/s
    public float health; // Damage needed to destroy this enemy
    public int score; // Points earned for destroying this

    private BoxCollider boxColl;

    void Awake()
    {
        boxColl = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        if (otherGO.GetComponent<Bullet>() != null)
        {
            Destroy(otherGO); // Destroy the Projectile
            Destroy(gameObject); // Destroy this box GameObject
        }
        // else if (otherGO.GetComponent<Ground>() != null)
        //{
        //    Destroy(gameObject); // Destroy this box GameObject
        //}
        else
        {
            Debug.Log("Enemy hit by object: " + otherGO.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
