using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform head;
    public float headFollowLerp = 2;

    public GameObject bullet;
    public float bulletSpeed = 5;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookTurrent();
        Shoot();
    }


    void LookTurrent()
    {
        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        worldMousePos.z = 0;

        if (worldMousePos.x < head.position.x) return;


        var direction = worldMousePos - head.position;
        direction.Normalize();

        head.right = Vector3.Slerp(head.right, direction, Time.deltaTime * headFollowLerp);

    }

    void Shoot()
    {
        if (!Input.GetMouseButtonUp(0)) return;


        var newBullet = GameObject.Instantiate(bullet);

        newBullet.transform.position = head.position;
        newBullet.transform.right = head.right;


        var newBulletRb = newBullet.GetComponent<Rigidbody2D>();

        newBulletRb.AddForce(head.right * bulletSpeed, ForceMode2D.Impulse);

    }
}
