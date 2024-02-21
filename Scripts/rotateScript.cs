using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour
{
    public Transform rotate;
    public Vector3 rotation = new Vector3(180,0,180);

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("ouch");
        if(other.CompareTag("Player")){
            rotate.Rotate(rotation);
        }
    }
}
