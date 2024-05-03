using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Breakable : MonoBehaviour
{

    public float breakSpeed = 5;

    public ParticleSystem particleSystem;

    private SpriteRenderer spriteRenderer;

    private bool broke = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (broke) return;


        var speed = collision.relativeVelocity.magnitude;

        Debug.Log($"Collided with speed: {speed}", gameObject);

        if (speed < breakSpeed) return;


        //Break Logic

        broke = true;

        collision.otherRigidbody.isKinematic = true;
        collision.otherCollider.enabled = false;


        spriteRenderer.enabled = false;

        if (particleSystem != null)
            particleSystem.Emit(10);

        Invoke("Kill", 2);

    }


    public void Kill()
    {
        Destroy(gameObject);
    }



}
