using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreupdate : MonoBehaviour
{
    public Text scoretext;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = string.Format("Score : " + score.curscore.ToString()); 
    }
}
