using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBuild : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Building;
    public GameObject Sprite;
    void Update()
    {
        
    }
    
    public void openB1()
    {
        Sprite.SetActive(false);
        Canvas.SetActive(false);
        Building.SetActive(true);
    }
}
