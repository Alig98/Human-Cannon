using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPS : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("destroy");
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
