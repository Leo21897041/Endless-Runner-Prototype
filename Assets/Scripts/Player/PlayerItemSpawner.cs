using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerItemSpawner : MonoBehaviour
{
    public List<GameObject> itemsList = new List<GameObject>();
    public bool canSpawnItem;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootForce;

    private void Update()
    {
        if (canSpawnItem)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Vector3 spawnDistance = new Vector3(0, 0, -2);
                Vector3 spawnPosition = transform.TransformPoint(spawnDistance);
                spawnPosition.y = 1f;
                Instantiate(itemsList[0], spawnPosition, Quaternion.identity);

                //canSpawnItem = false;
            }
            if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
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
}
