using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using static UnityEngine.ParticleSystem;

public class ObjectsLevitator : MonoBehaviour
{
    //public List<GameObject> levitatingObjects;


    public Rigidbody2D testObject;

    public float levitateForce = 1;

    public float randomFactor = 0.2f;

    public LayerMask castMask = ~1;

    public ParticleSystem particles;
    private void Awake()
    {
        //levitatingObjects= new List<GameObject>();

        //GameObject.Findobj<
    }
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMousePos.z = -2;





            RaycastHit2D hit = Physics2D.Raycast(worldMousePos, Vector2.zero, 10, castMask);

            if (hit.collider != null && hit.rigidbody != null)
            {
                particles.transform.position = worldMousePos;
                particles.Emit(8);

                LevitateObject(hit.rigidbody,hit.point);
            }
        }



        if (Input.GetMouseButtonDown(1))
        {



        }
    }

    void LevitateObject(Rigidbody2D objectBody, Vector2 point)
    {
        var objVerticalVelocity = objectBody.velocity.y;

        //math.remap(-20,0,)

        //Mathf.re
        if (objVerticalVelocity < 0)
        {
            objectBody.velocity = new Vector2(objectBody.velocity.x, 0);
        }

        var mainDirection = objectBody.worldCenterOfMass - point;
        mainDirection.Normalize();

        objectBody.AddForce(mainDirection * levitateForce, ForceMode2D.Impulse);

        var randomDirection = UnityEngine.Random.insideUnitCircle;
        randomDirection.y = Mathf.Abs(randomDirection.y);

        objectBody.AddForce(randomDirection * randomFactor, ForceMode2D.Impulse);
    }
}
