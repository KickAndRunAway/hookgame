using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame() //betritt level wenn knopf gedr�ckt
    {
        SceneManager.LoadScene(1);
    }
}
