using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;
    public int maxPlayers;

    public HashSet<InputDevice> joinedDevices = new HashSet<InputDevice>();

    void Update()
    {
        if(joinedDevices.Count >= maxPlayers) { return; }

        foreach (var gamePad in Gamepad.all)
        {
            if (joinedDevices.Contains(gamePad)) continue;

            if (gamePad.aButton.wasPressedThisFrame)
            {
                int playerIndex = joinedDevices.Count;

                PlayerInput.Instantiate(playerPrefab,
                    playerIndex: playerIndex,
                    controlScheme: "Gamepad",
                    pairWithDevice: gamePad);

                joinedDevices.Add(gamePad);
            }


            if (joinedDevices.Count >= maxPlayers) { break; }
        }
    }
}
