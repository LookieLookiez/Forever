using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 6f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float verticalSpeed = 20;
	[HideInInspector]
	public bool lookingRight = true;
	bool doubleJump = false;
	public GameObject Boost;
	
	private Animator cloudanim;
	public GameObject Cloud;


	private Rigidbody2D rb2d;
	private Animator anim;
	private bool isGrounded = false;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//cloudanim = GetComponent<Animator>();

		Cloud = GameObject.Find("Cloud");
  		//cloudanim = GameObject.Find("Cloud(Clone)").GetComponent<Animator>();
	}


    void OnTriggerStay2D(Collider2D other)
    {
        float hor = Input.GetAxis("Horizontal");
        if (other.gameObject.CompareTag("Vines"))
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = Vector2.zero;
            Debug.Log("Im in vines!");
            if(Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W)))
            {
                rb2d.velocity = Vector2.up * maxSpeed;
                //rb2d.AddForce(20F * Vector3.up);

            }
            if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.S)))
            {
                rb2d.velocity = Vector2.down * maxSpeed;
                //rb2d.AddForce(20F * Vector3.up);

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Vines"))
        {
            rb2d.gravityScale = 1;
        }
    }



    // Update is called once per frame
    void Update () {

        

	}


	void FixedUpdate()
	{
		if (isGrounded) 
			doubleJump = false;


		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		  
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();
		 
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}


	
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

}
