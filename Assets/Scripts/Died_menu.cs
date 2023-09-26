using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died_menu : MonoBehaviour
{
    public static bool Player_died = false;
    public GameObject player;
    public GameObject Died_menuUI;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<Player>().died == true) 
        {
            Show_Died_Screen();
        }
    }

    void Show_Died_Screen() 
    {
        Died_menuUI.SetActive(true);
        Time.timeScale = 0f;
        Player_died = true;
    }
}   
