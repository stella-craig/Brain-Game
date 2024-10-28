using System.Collections;
using UnityEngine;
using TMPro;

public class CrateSpawner : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject cratePrefab;
    public float spawnInterval = 2f;
    public float swayAmount = 0.5f;
    public float swaySpeed = 2f;
    public int maxCrateValue = 10;
    public float fallSpeed = 1f;
    private float camWidth;
    private float camHeight;

    void Start()
    {
        camHeight = Camera.main.orthographicSize * 2f;
        camWidth = camHeight * Camera.main.aspect;
    }

    public IEnumerator SpawnCrates()
    {
        while(true)
        {
            SpawnCrate();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public bool AreAllCratesDestroyed()
    {
        return GameObject.FindGameObjectsWithTag("Crate").Length == 0;
    }


    public void SpawnCrate()
    {
        //Debug.Log("SpawnCrate called at game start", this);
        float xPosition = Random.Range(-camWidth/2, camWidth/2);
        Vector3 spawnPos = new Vector3(xPosition, 7.5f, 0);

        GameObject crate = Instantiate(cratePrefab, spawnPos, Quaternion.identity);
        crate.AddComponent<BoundsCheck>();

        // Generate and set a random crate value between 1 and maxCrateValue
        int crateValue = Random.Range(1, maxCrateValue + 1);

        // Call Init on CrateFall with the crate's value
        CrateFall crateFall = crate.GetComponent<CrateFall>();
        if (crateFall != null)
        {
            crateFall.Init(swayAmount, swaySpeed, fallSpeed, crateValue); // Pass crateValue to Init
        }
    }

}
