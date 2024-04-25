using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource source;
    private static AudioControl instance;

    private void Awake()
    {
        source.time = 14.8f; //musik wird abgespielt wenn man das level betritt

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; //die musik spielt weiter trotz neustarts
            DontDestroyOnLoad(gameObject);
        }
    }
}
