using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public int health;
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -20)
        {
            Debug.Log("player has died");
            hasDied = true;
        }
        if (hasDied== true)
        {
            StartCoroutine("Die");
        }
        
        
    }
    IEnumerator Die()
    {
        Debug.Log("player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player has died");
    }
}
