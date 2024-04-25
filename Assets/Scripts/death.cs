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
    private float i = 161f;
    public DeathTime DeathTime;
    public GameObject transition;

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

        if (Input.GetKey("r") && i > 319f || triggerActive || timer > deathTime)
        {
            transition.transform.localPosition = new Vector3(transition.transform.localPosition.x, 1600f, transition.transform.localPosition.z);
            i = 1f;
        }

        if (i < 160f)
        {
            transition.transform.localPosition = new Vector3(transition.transform.localPosition.x, 1600f - Mathf.Sqrt(i * 16000), transition.transform.localPosition.z);
            i++;
        }

        else if (i == 160f)
        {
            Restart();
            i++;
        }

        else if (i < 320f)
        {
            transition.transform.localPosition = new Vector3(transition.transform.localPosition.x, -Mathf.Pow((i-160f)/4, 2f), transition.transform.localPosition.z);
            i++;

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
        DeathTime.deathTime += 15;
    }
}
