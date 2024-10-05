using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerorCPUMenu : MonoBehaviour
{
    public void OnVSPlayerButton(){
        SceneManager.LoadScene("vsPlayer");
    }
    public void OnVSCPUButton(){
        SceneManager.LoadScene("vsCPU");
    }
}