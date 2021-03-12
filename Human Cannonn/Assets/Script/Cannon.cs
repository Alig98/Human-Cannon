using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cannon : MonoBehaviour
{
    public GameObject dir;
    private float rotateAmount;
    private bool canRotateY;
    private bool canRotateZ;
    private int clickCount;
    private float slideAmount;
    private bool canSlide;
    private bool canShoot;
    private bool canRedo;
    public GameObject slider;
    public GameObject human;
    public float power;
    public int humanCount;
    public GameObject ps;
    void Start()
    {
        humanCount = 0;
        canRedo = false;
        clickCount = 0;
        canRotateY = true;
        canRotateZ = false;
        canSlide = false;
        canShoot = false;
        rotateAmount = 80f;
        slideAmount = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotateY && humanCount > 0)
        {
            if ((int)transform.rotation.eulerAngles.y == 45)
            {
                rotateAmount = -80f;
            }
            if ((int)transform.rotation.eulerAngles.y == 315)
            {
                rotateAmount = 80f;
            }
            transform.Rotate(0, rotateAmount * Time.deltaTime, 0);
        }
        if (canRotateZ && humanCount > 0)
        {
            if ((int)transform.rotation.eulerAngles.z == 315)
            {
                rotateAmount = -80f;
            }
            if ((int)transform.rotation.eulerAngles.z == 1)
            {
                rotateAmount = 80f;
            }
            transform.Rotate(0, 0, -rotateAmount * Time.deltaTime);
        }
        if (canSlide && humanCount > 0)
        {
            if ((int) slider.transform.localPosition.y+84 == 200)
            {
                slideAmount = -200f;
            }
            if ((int) slider.transform.localPosition.y+84 == 0f)
            {
                slideAmount = 200f;
            }
            slider.transform.localPosition += new Vector3(0, slideAmount*Time.deltaTime, 0);
            power = slider.transform.localPosition.y + 84;
        }
        if (canShoot && humanCount > 0)
        {
            Camera.main.GetComponent<camerafollow>().smoothSpeed = 0.02f;
            human.transform.GetChild(2).GetComponent<shoot>().power = power;
            Instantiate(ps, dir.transform.position, Quaternion.identity);
            Instantiate(human, dir.transform.position,dir.transform.rotation);
            canShoot = false;
            humanCount -= 1;
            canRedo = true;


        }
        if (clickCount == 1 && humanCount > 0)
        {
            canRotateY = false;
            canRotateZ = true;
        }
        if (clickCount == 2 && humanCount > 0)
        {
            canRotateZ = false;
            canSlide = true;
        }
        if (clickCount == 3 && humanCount > 0)
        {
            canSlide = false;
            canShoot = true;
            clickCount += 1;
        }
        if (Input.GetMouseButtonDown(0) && humanCount > 0)
        {
            clickCount += 1;
            rotateAmount = 80f;
        }
        if (Input.GetMouseButtonDown(0) && humanCount > 0 && canRedo)
        {
            gameObject.transform.rotation = new Quaternion(0,0,0,0);
            slider.transform.localPosition = new Vector3(slider.transform.localPosition.x, -84, slider.transform.localPosition.z);
            canRedo = false;
            clickCount = 0;
            canRotateY = true;
            canRotateZ = false;
            canSlide = false;
            canShoot = false;
            rotateAmount = 80f;
            slideAmount = 200f;
            Camera.main.GetComponent<camerafollow>().target = transform;
            Camera.main.GetComponent<camerafollow>().offset = new Vector3(30, 15, 0);
            Camera.main.GetComponent<camerafollow>().smoothSpeed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
