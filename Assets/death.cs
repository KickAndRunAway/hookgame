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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r") || triggerActive)
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
