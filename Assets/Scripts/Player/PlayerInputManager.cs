using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInputManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerPanelPrefab;
    public GameObject canvas;
    public Transform[] spawnPoints;
    public int maxPlayers;
    public GameObject enemyObj;
    public Color[] playerColors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };
    public Color[] panelColors = new Color[] { new Color(1f, 0f, 0f, 0.25f), new Color(1f, 0f, 0f, 0.25f), new Color(0f, 1f, 0f, 0.25f), new Color(0f, 1f, 1f, 0.25f) };
    public List<Vector3> panelPositions = new List<Vector3>();
    public HashSet<InputDevice> joinedDevices = new HashSet<InputDevice>();

    void Update()
    {
        if(joinedDevices.Count >= maxPlayers) { return; }

        foreach (var gamePad in Gamepad.all)
        {
            if (joinedDevices.Contains(gamePad)) continue;

            if (gamePad.buttonSouth.wasPressedThisFrame)
            {
                int playerIndex = joinedDevices.Count;
                enemyObj.SetActive(true);

                GameObject playerPanel = Instantiate(playerPanelPrefab, canvas.transform);
                RectTransform rectTransform = playerPanel.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = panelPositions[playerIndex];

                playerPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Player " + (playerIndex + 1);
                playerPanel.GetComponent<Image>().color = panelColors[playerIndex];

                PlayerInput newPlayer = PlayerInput.Instantiate(playerPrefab,
                    playerIndex: playerIndex,
                    controlScheme: "Gamepad",
                    pairWithDevice: gamePad);

                newPlayer.GetComponent<PlayerMovement>().isKeyboard = false; 
                playerPanel.GetComponent<ScorekeeperManager>().playerManager = newPlayer.gameObject.GetComponent<PlayerManager>();
                
                joinedDevices.Add(gamePad);

                ApplyColor(newPlayer.gameObject, playerIndex);
            }

            if (joinedDevices.Count >= maxPlayers) { break; }
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (joinedDevices.Contains(Keyboard.current)) return;

            enemyObj.SetActive(true);

            int playerIndex = joinedDevices.Count;

            GameObject playerPanel = Instantiate(playerPanelPrefab, canvas.transform);
            RectTransform rectTransform = playerPanel.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = panelPositions[playerIndex];

            playerPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Player " + (playerIndex + 1);
            playerPanel.GetComponent<Image>().color = panelColors[playerIndex];

            PlayerInput newPlayer = PlayerInput.Instantiate(playerPrefab,
                playerIndex: playerIndex,
                controlScheme: "Keyboard&Mouse",
                pairWithDevice: Keyboard.current);

            newPlayer.GetComponent<PlayerMovement>().isKeyboard = true;
            playerPanel.GetComponent<ScorekeeperManager>().playerManager = newPlayer.gameObject.GetComponent<PlayerManager>();

            joinedDevices.Add(Keyboard.current);

            ApplyColor(newPlayer.gameObject, playerIndex);

            //if (joinedDevices.Count >= maxPlayers) { break; }
        }
    }
    private void ApplyColor(GameObject obj, int index)
    {
        MeshRenderer playerRenderer = obj.GetComponentInChildren<MeshRenderer>();

        if (playerRenderer != null && index <= maxPlayers)
        {
            playerRenderer.material.color = playerColors[index];
        }
    }
}
