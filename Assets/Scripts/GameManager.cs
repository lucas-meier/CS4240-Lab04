using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Serializable]
    public class PortalInfos
    {
        public GameObject camera1;
        public GameObject camera2;
        public GameObject portal1;
        public GameObject portal2;
    }
    public GameObject player;
    private Vector3 playerPos;
    private int playerPosCount = 0;
    const int playerPosLimit = 3;

    public PortalInfos portalInfos;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
        if (Math.Abs(player.transform.position.y - playerPos.y) > 1e-4)
        {
            playerPosCount--;   
        }
        else
        {
            playerPosCount = Math.Max(playerPosLimit, playerPosCount + 1);
        }
        if (playerPosCount < 0)
        {
            playerPos = player.transform.position;
        }
    }

    public Vector3 PlayerPosition()
    {
        return new Vector3(
            player.transform.position.x,
            playerPos.y,
            player.transform.position.z
            );
    }
}
