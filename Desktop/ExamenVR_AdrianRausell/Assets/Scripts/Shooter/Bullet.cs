using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;
    private float bulletSpeed = 100;
    private Rigidbody rb;
    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy (gameObject,lifeTime);
        Launch();
    }

    // Update is called once per frame
    private void Launch()
    {
        rb.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
    }
}
