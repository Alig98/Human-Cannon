using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 dragTowards;
    public GameObject childs;
    public GameObject cannon;
    public GameObject canvas;
    public GameObject boss;

    void Update()
    {
        for(int i =0 ; i < childs.transform.childCount-1; i++)
        {
            childs.transform.GetChild(i + 1).GetComponent<Character>().follow = childs.transform.GetChild(i).gameObject;
        }
        if (Input.GetMouseButton(0) && childs.transform.childCount>1)
        {
            mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            dragTowards = (transform.position - mousePos);
            transform.forward = new Vector3(dragTowards.x, 0, -dragTowards.z * 2f);
            transform.position+= transform.forward * 15f*Time.deltaTime;
        }
        if (childs.transform.childCount == 1)
        {
            Camera.main.GetComponent<camerafollow>().target = cannon.transform;
            Camera.main.GetComponent<camerafollow>().smoothSpeed = 0.05f;
            canvas.SetActive(true);
            boss.GetComponent<Zombie>().canStart = true;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "finish")
        {
            Camera.main.GetComponent<camerafollow>().target = other.transform;
        }
    }

}
