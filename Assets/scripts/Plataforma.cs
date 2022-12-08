using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float tempoPlataforma;
    private TargetJoint2D target;
    private BoxCollider2D colider;
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        colider = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D colission)
    {
        if (colission.gameObject.tag == "Player")
        {
            Invoke("cair", tempoPlataforma);
        }

        if (colission.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
    
    void cair()
    {
        target.enabled = false;
        colider.isTrigger = true;
    }

}
