using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public Text coins;
    public GameObject locked;
    public Text lockedText;
    public Button buttonLevel1;


    // Start is called before the first frame update
    void Start()
    {
        Level0();
    }
    private void DesactivateAll()
    {
        locked.SetActive(false);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false); //level 0
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false); //level 1
    }
    private void Level0()
    {
        DesactivateAll();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }


    private void Level1()
    {
        DesactivateAll();
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        buttonLevel1.enabled = true;

        if (int.Parse(coins.text) < 150)
        {
            locked.SetActive(true);
            lockedText.text = "Minimum coins: 150";
            buttonLevel1.enabled = false;
        }
    }


    public void Next()
    {
        bool level0 = transform.GetChild(0).gameObject.active;
        bool level1 = transform.GetChild(1).gameObject.active;

        if (level0)
            Level1();

        if (level1)
           Level0();
         
    }
}
