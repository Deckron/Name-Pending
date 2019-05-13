using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_health : MonoBehaviour
{
    public int drag_health;
    public bool hasDied;
    private bool collided;
    private Animator _animator;
    //find a way to detect collision with a character
    // Start is called before the first frame update
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("check3");
        if (collision.gameObject.name == "Knight" && _animator.GetBool("onAttack") == true)
        {
            collided = true;
            Hit();
            //Debug.Log("touching");
        }
    }
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
        if (hasDied == true)
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
    void Hit()
    {
        drag_health -= 1;
        if(drag_health==0)
        {
            Debug.Log("dragon health is zero");
            DestroyEnt();
        }
    }
    void DestroyEnt()
    {
        Destroy(gameObject);
    }
}
