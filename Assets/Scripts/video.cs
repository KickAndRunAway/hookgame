using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    void Start()
    {
        GetComponent<VideoPlayer>().isLooping = true;
    }
}
