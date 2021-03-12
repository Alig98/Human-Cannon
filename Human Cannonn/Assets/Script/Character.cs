using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 dragTowards;
    private Animator myAnim;
    public GameObject follow;
    public GameObject parent;
    public GameObject ragdoll;
    public GameObject cannon;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        myAnim.SetFloat("speed",rb.velocity.magnitude);
        if (Input.GetMouseButton(0))
        {
            dragTowards = (follow.transform.position - transform.position);
            transform.forward = new Vector3 (dragTowards.x,0,dragTowards.z);
            Debug.Log(dragTowards.sqrMagnitude);
            if (dragTowards.sqrMagnitude >=2.1f)
            {
                rb.velocity = transform.forward * 15f;
            }

        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stack")
        {
            other.transform.SetParent(parent.transform);
            other.GetComponent<Character>().enabled = true;
        }
        if(other.gameObject.tag == "Engel")
        {
            Instantiate(ragdoll,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Destroyable")
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "finish")
        {
            Camera.main.GetComponent<camerafollow>().target = other.transform;
            cannon.GetComponent<Cannon>().humanCount += 1;
            Destroy(gameObject);
        }
    }

}
