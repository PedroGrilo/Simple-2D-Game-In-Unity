using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void LoadGameLevel0(){
        SceneManager.LoadScene(1);
    }
    public void LoadGameLevel1()
    {
        SceneManager.LoadScene(2);
    }
}
