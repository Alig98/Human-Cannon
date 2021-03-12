using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float power;
    public Rigidbody pelvis;
    public GameObject cannon;
    public GameObject ps;
    public GameObject parent;
    void Start()
    {
        Camera.main.GetComponent<camerafollow>().target = pelvis.transform;
        pelvis.AddForce(transform.right*5*power, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hit")
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Animator>().SetTrigger("hit");
            collision.gameObject.GetComponent<Zombie>().currentHealth -= 50;
            Camera.main.GetComponent<camerafollow>().target = cannon.transform;
            Camera.main.GetComponent<camerafollow>().offset = new Vector3(30, 15, 0);
            Camera.main.GetComponent<camerafollow>().smoothSpeed = 1f;
            Destroy(parent);
        }
        if (collision.gameObject.tag == "Zemin")
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(parent);
        }
    }

}
