using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitApplicationButton(){
        Application.Quit();
    }

     public void LoadGame(){
           SceneManager.LoadScene("JustInCase");
    }
}
