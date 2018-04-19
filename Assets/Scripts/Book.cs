using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
    
    private void Start()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerControler>().OutsideForce(GetComponent<Rigidbody>().angularVelocity);
        }
        Destroy(this.gameObject);
    }
}
