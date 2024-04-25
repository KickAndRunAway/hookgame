using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Loading : MonoBehaviour
{
    private float timer;
    public GameObject Panel;
    void Start()
    {
        
    }

    void Update() //verbirgt das menü bis die animation geladen hat
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Panel.SetActive(false);
        }
    }
}
