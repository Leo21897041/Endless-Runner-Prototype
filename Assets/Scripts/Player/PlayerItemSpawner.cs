using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerItemSpawner : MonoBehaviour
{
    private PlayerManager playerManager;
    public List<GameObject> itemsList = new List<GameObject>();
    public bool canSpawnItem;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootForce;
    public bool isAlive;
    public Color[] playerColors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };

    private void Start()
    {
        isAlive = true;
        playerManager = GetComponent<PlayerManager>();
    }
    public void PlaceItem()
    {
        if (canSpawnItem)
        {
            if (isAlive)
            {
                Vector3 spawnDistance = new Vector3(0, 0, -2);
                Vector3 spawnPosition = transform.TransformPoint(spawnDistance);
                spawnPosition.y = 1f;
                Instantiate(itemsList[0], spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(itemsList[0], transform.position, Quaternion.identity);
            }

            //canSpawnItem = false;
        }
    }
    public void Shoot()
    {
        if (canSpawnItem && playerManager.isAlive)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            if (newBullet.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(shootForce * bulletSpawnPoint.forward * Time.fixedDeltaTime, ForceMode.Impulse);
            }
            //canSpawnItem = false;
        }
    }
}
