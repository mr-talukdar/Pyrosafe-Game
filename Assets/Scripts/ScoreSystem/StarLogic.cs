using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarLogic : MonoBehaviour
{

    public List<Image> stars;

    public float bestTime=60f;
    [SerializeField]private bool _correctClass=false;

    [SerializeField]private bool _minTime=false;

    [SerializeField]private bool _correctGuisher=false;

    [SerializeField]private bool timeOver=false;
    int score;
   

    // Update is called once per frame
    void Update()
    {
        Score();
        RewriteTheStars();
        if (score == 3)
        {
            timeOver = true;
        }
    }

    private void RewriteTheStars()
    {
        for (int i = 0; i < score; i++)
        {
            stars[i].gameObject.SetActive(true);
        }
        
    }

    public void Score()
    {
         
        if (_correctClass && _correctGuisher && _minTime)
        {
            score = 3;
        }
        else if ((_correctClass && _correctGuisher) || (_correctClass && _minTime) || (_correctGuisher && _minTime))
        {
            score = 2;
        }
        else if (_correctClass || _correctGuisher || _minTime)
        {
            score = 1;
        }

        if (this.GetComponent<Timer>().timeRemaining>bestTime&&_correctClass&&_correctGuisher)
        {
            SetMinTime();
        }
    }
    
    public void SetCorrectClass()
    {
        _correctClass = true;
    }
    public void SetMinTime()
    {
        _minTime = true;
    }
    public void SetCorrectGuisher()
    {
        _correctGuisher = true;
    }
    
    
}
