using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().isLooping = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
