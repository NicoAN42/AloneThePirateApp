﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gameMaster : MonoBehaviour {

    public int points;

    public Text pointsText;
    
    void Update()
    {
        pointsText.text = ("Points: " + points);
    }
}
