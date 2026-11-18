using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject carMesh;
    public GameObject deadObj;
    public PlayerMovement playerMovement;
    public PlayerItemSpawner playerItemSpawner;
    public GameObject deadPlayer;
    public int score;
    public bool isAlive;
    public bool gameStart;

    private void Start()
    {
        isAlive = true;
        gameStart = false;

        playerItemSpawner = GetComponent<PlayerItemSpawner>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (gameStart)
        {
            score++;
        }
    }
    public void Dead()
    {
        GameObject spawnedDeadPlayer = Instantiate(deadPlayer, transform.position, Quaternion.identity, transform);

        deadObj = spawnedDeadPlayer;
        ApplyColor(deadObj);
        isAlive = false;
        playerMovement.isAlive = false;
        playerItemSpawner.isAlive = false;

        carMesh.SetActive(false);        
        deadObj.SetActive(true);

        playerMovement.leftPS.SetActive(false);
        playerMovement.rightPS.SetActive(false);

        gameStart = false;
    }
    private void ApplyColor(GameObject obj)
    {
        MeshRenderer deadRenderer = obj.GetComponent<MeshRenderer>();

        deadRenderer.material.color = carMesh.GetComponentInChildren<MeshRenderer>().material.color;
        
    }
}
