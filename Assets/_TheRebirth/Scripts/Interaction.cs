using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    

    public UnityEvent onInteract;
    public float radius;
    public SphereCollider sphereCollider;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        radius = sphereCollider.radius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }



    void OnTriggerEnter(Collider other){
      if (other.gameObject.tag == "Player"){
      }
    }

}
