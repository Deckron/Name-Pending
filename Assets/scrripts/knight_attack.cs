using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_attack : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            _anim.SetBool("onAttack", true);
            
           
        }
        else
        {
            _anim.SetBool("onAttack", false);
        }
        
        
    }
}
