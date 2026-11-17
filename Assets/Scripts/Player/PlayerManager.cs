using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int score;
    public bool isAlive;
    public bool gameStart;

    private void Start()
    {
        isAlive = true;
        gameStart = false;
    }

    private void Update()
    {
        if (gameStart)
        {
            score++;
        }
    }
}
