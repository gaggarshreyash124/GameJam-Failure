using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private float Timer = 0f;
    public bool isB1;
    public bool isB2;

    void Start()
    {
        playerData.DevpointsB1 = 100;
        playerData.DevpointsB2 = 150;
        
    }

    void Update()
    {

        Timer += Time.deltaTime;
        playerData.DevpointsB1 = 100 + (playerData.VillagerSaved * 10);
        playerData.DevpointsB2 = 150 + (playerData.VillagerSaved * 10);

        if (Timer >= playerData.Interval)
        {
            Timer = 0f;
            if (playerData.B1unlocked && isB1)
            {
                playerData.DevelopmentPoints += playerData.DevpointsB1;
                playerData.Coins += 20;
            }
            else if (playerData.B2unlocked && isB2)
            {
                playerData.DevelopmentPoints += playerData.DevpointsB2;
                playerData.Coins += 30;
            }

        }
    }
}
