using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStart;

    private void Start()
    {
        isStart = false;
    }
    public void StartGame()
    {
        StartCountdownTimer();
    }

    private IEnumerator StartCountdownTimer()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1f);
        
        yield return null;
    }
}
