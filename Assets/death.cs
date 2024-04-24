using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    //public BoxCollider2D top;
    //public BoxCollider2D bottom;
    //public BoxCollider2D side;
    private bool triggerActive = false;
    public float deathTime = 180;
    public int fuelTanks = 0;
    private float timer = -3;

    private void OnTriggerEnter2D(Collider2D other) //player in der hitbox
    {
        triggerActive = true;
    }

    public void OnTriggerExit2D(Collider2D other) //player nicht in der hitbox
    {
        triggerActive = false;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey("r") || triggerActive || timer > deathTime)
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void increaseDeathTime()
    {
        deathTime += 15;
        fuelTanks++;
    }
}
