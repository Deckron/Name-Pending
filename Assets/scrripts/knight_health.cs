using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_health : MonoBehaviour
{
    public int kni_health;
    public bool hasDied;
    private bool collided;
    private Animator _animator; 
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("check2");
        if (collision.gameObject.name == "Dragon" && _animator.GetBool("onAttack") == true)
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
    void Hit()
    {
        kni_health -= 1;
        if(kni_health==0)
        {
            Debug.Log("knight last zero health");
            DestroyEnt();
        }
    }
    void DestroyEnt()
    {
        Destroy(gameObject);
    }
}
