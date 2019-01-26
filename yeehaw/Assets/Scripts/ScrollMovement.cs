using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour

{
    private Rigidbody2D RIGIDBODY;
    private float speed = 0.2f;
    [SerializeField] bool stopScrolling;

    // Start is called before the first frame update
    void Start()
    {
        RIGIDBODY = GetComponent<Rigidbody2D>();
        RIGIDBODY.velocity = new Vector2(0, speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopScrolling)
        {
            RIGIDBODY.velocity = Vector2.zero;
        }
        else
        {
            RIGIDBODY.velocity = new Vector2(0, speed);
        }
        
    }
}
