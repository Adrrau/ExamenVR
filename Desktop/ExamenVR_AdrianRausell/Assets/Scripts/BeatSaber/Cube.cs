using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float cubeSpeed = 2.0f;
    private float deleteTimer = 8.0f;
    private bool changeScale = false;
    public bool orangeCube;
    public bool blueCube;
    public Material red;
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        //rig.isKinematic = false;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, cubeSpeed*Time.deltaTime);
        deleteTimer -= Time.deltaTime;
        if (deleteTimer <= 0)
        {
            Destroy(gameObject);
        }
        if (changeScale == true)
        {
            transform.localScale -= new Vector3(0.10f * Time.deltaTime ,0.10f * Time.deltaTime ,0.10f * Time.deltaTime );
        }
    }

    public void OnCollisionEnter (Collision other)
    {
        if (orangeCube)
        {
            if (other.gameObject.CompareTag("SwordOrange"))
            {
                Debug.Log("hit");
                GameManager.score += 10;
                GetComponent<TrailRenderer>().widthMultiplier = 0.2f;
                deleteTimer = 2.0f;
                cubeSpeed = 0f;
                changeScale = true;
                rig.useGravity = true;
                

            }
            else if (other.gameObject.CompareTag("SwordBlue"))
            {
                GameManager.score -= 5;
                gameObject.GetComponent<MeshRenderer>().material = red;
                rig.useGravity = true;
                deleteTimer = 2.0f;
                cubeSpeed = 0f;
                changeScale = true;
            }
        }

         if (blueCube)
        {
            if (other.gameObject.CompareTag("SwordBlue"))
            {
                Debug.Log("hit");
                GameManager.score += 10;
                GetComponent<TrailRenderer>().widthMultiplier = 0.2f;
                deleteTimer = 2.0f;
                cubeSpeed = 0f;
                changeScale = true;
                rig.useGravity = true;
                
            }

            else if (other.gameObject.CompareTag("SwordOrange"))
            {   
                GameManager.score -= 5;
                gameObject.GetComponent<MeshRenderer>().material = red;
                deleteTimer = 2.0f;
                cubeSpeed = 0f;
                changeScale = true;
                rig.useGravity = true;
            }
        }
    }
}
