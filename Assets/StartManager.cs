using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject mobileControls; 
    public GameObject startPanel;
  

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        // Hi?n panel lúc ??u + d?ng game
        startPanel.SetActive(true);
     
        Time.timeScale = 0f;

        mobileControls.SetActive(false); // ?n lúc ??u

    }

    public void StartGame()
    {
        // ?n panel + ch?y game
        startPanel.SetActive(false);
        Time.timeScale = 1f;

        mobileControls.SetActive(true); // hi?n khi b?t ??u

    }

}
