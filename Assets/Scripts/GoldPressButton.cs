using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPressButton : MonoBehaviour
{
    Color changeColor;
    Graphic graphic;

    // Start is called before the first frame update
    void Start()
    {
        graphic = GetComponent<Graphic>();
    }

    // Update is called once per frame
    void Update()
    {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount <= 100)
        {
            changeColor = Color.red;
            graphic.color = changeColor;
        }
        else
        {
            changeColor = Color.green;
            graphic.color = changeColor;
        }
    }
}
