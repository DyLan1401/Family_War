using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
 
    public GameObject startPanel;
  

    void Start()
    {
        // Hi?n panel lúc ??u + d?ng game
        startPanel.SetActive(true);
     
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        // ?n panel + ch?y game
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
