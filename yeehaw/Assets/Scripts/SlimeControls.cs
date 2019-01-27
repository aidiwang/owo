using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControls : MonoBehaviour
{

	public float speed;
	public Vector2 jumpHeight;
    public Vector2 jump2Height;
	Rigidbody2D rb2d;
	public Animator animator;
	bool jumping = false;
    bool falling = false;
    bool dead = false;
    bool jump2 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation=true;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    	// rb2d.position += move * speed * Time.deltaTime;

    	float move = Input.GetAxisRaw("Horizontal");

    	if (move > 0 && !dead) {
    		rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
    		transform.localScale = new Vector2(1, 1);
    	}
    	else if (move < 0 && !dead) {
    		rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
    		transform.localScale = new Vector2(-1, 1);
    	}
    	else {
    		rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    	}

    	//Vector2 jump = new Vector2(0, Input.GetAxisRaw("Vertical"));
    	//rb2d.position += jump * jumpspeed * Time.deltaTime;

    	if (Input.GetKeyDown(KeyCode.Space) && !jumping && !falling && !jump2) {
            SoundScript.PlaySound("jump");
    		animator.SetBool("isJumping", true);
    		Debug.Log("jump");
    		// Vector2 jump = new Vector2(0, 1);
    		// rb2d.position += jump * jumpspeed * Time.deltaTime;
    		rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
    		jumping = true;
            // jumping();
        }
        if (Input.GetKeyUp(KeyCode.Space) && jumping && !falling && !jump2){
            jumping = false;
            falling = true;
            jump2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !jumping && falling && jump2) {
            SoundScript.PlaySound("jump");
            animator.SetBool("doubleJumping", true);
            Debug.Log("jump2");
            // Vector2 jump = new Vector2(0, 1);
            // rb2d.position += jump * jumpspeed * Time.deltaTime;
            rb2d.AddForce(jump2Height, ForceMode2D.Impulse);
            falling = false;
    	}

        
    	// else{
    	// 	animator.SetBool("isJumping", false);
    	// }

    	// if(Input.GetKeyDown(KeyCode.DownArrow)){
    	// 	animator. SetBool("isJumping", false);
    	// }
    }

    void OnCollisionEnter2D(Collision2D col){
    	// Collider2D collider = col.collider;
    	// Vector2 contactPoint = col.contacts[0].point;
    	// Vector2 center = collider.bounds.center;
    	// bool bottom = contactPoint.y > center.y;
    	// if (bottom){
        float move = Input.GetAxisRaw("Horizontal");

    	animator.SetBool("isJumping", false);
        animator.SetBool("doubleJumping", false);
    	Debug.Log("land");
    	// jumping = false;
        jumping = false;
        jump2 = false;
        falling = false;
    	// }

        if (col.gameObject.tag == "DangerObject") {
            SoundScript.PlaySound("pop");
            animator.SetBool("isDangerous", true);
            dead = true;
            Debug.Log("you died.");
        }

        if (col.gameObject.tag == "Wall" && System.Math.Abs(move) > 0) {
            SoundScript.PlaySound("squish1");
            animator.SetBool("wallHug", true);
        }
        else {
            animator.SetBool("wallHug", false);
        }
        
    }

    // void jumping()
    // {
    // 	yield WaitForSeconds(animations["slime_jump"].clip.length);
    // 	animator.SetBool("isJumping", false);
    // }


}
