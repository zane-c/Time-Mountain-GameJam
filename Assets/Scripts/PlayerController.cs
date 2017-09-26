using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	// Physics
	private float jumpForce = 11f;
	private float maxSpeed = 15f;
	private bool facingRight = true;

	private bool isGrounded = true;
	private float groundRadius = 0.2f;
	private int numberOfJumps = 2;
	public Transform groundCheck;
	public LayerMask whatIsGround;

    //Coins
	private int coins = 0;
	public Text coinCount;
    AudioSource source;
    AudioClip coin;

    //Fade
    private bool dead = false;
    private bool win = false;
    private GameObject black;
    private GameObject white;
    private Image b_img;
    private Image w_img;
    public double decrement = 0.0000000000001;


    // Game objects
    private Animator anim;
	private Rigidbody2D rb;

	void Start () {
		// Initialize variables
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
        coin = (AudioClip)Resources.Load("coin_sound");
        source = rb.GetComponent<AudioSource>();

        // Initialize fade coroutine objects and reset alpha to 0
        black = GameObject.Find("BlackScreen");
        white = GameObject.Find("WhiteScreen");

        b_img = black.GetComponent<Image>();
        w_img = white.GetComponent<Image>();

        var btempColor = b_img.color;
        btempColor.a = 0.0f;
        b_img.color = btempColor;

        var wtempColor = w_img.color;
        wtempColor.a = 0.0f;
        w_img.color = wtempColor;


        // Set parameters
        rb.freezeRotation = true;
	}

	void Update () {

		if (isGrounded) {
			numberOfJumps = 2;
		}
		if (numberOfJumps > 1 && Input.GetKeyDown(KeyCode.Space)) {
			numberOfJumps -= 1;
			anim.SetBool("isGrounded", false);

			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}

	void FixedUpdate() {

        if (dead)
        {
            Fade(b_img);
        } else if (win)
        {
            Fade(w_img);
        }
		// Ground & jumping
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		// X-axis movement
		if (isGrounded) {
			maxSpeed = 10f;
		} else {
			maxSpeed = 8f;
		}
		float xSpeed = Input.GetAxis("Horizontal") * maxSpeed;
		float ySpeed = rb.velocity.y;
		rb.velocity = new Vector2(xSpeed, rb.velocity.y);

		// Sprite flipping
		if (xSpeed > 0 && !facingRight) {
			Flip();
		} else if (xSpeed < 0 && facingRight) {
			Flip();
		}

		// Set Animation parameters
		anim.SetFloat("xSpeed", Mathf.Abs(xSpeed));
		anim.SetBool("isGrounded", isGrounded);
		anim.SetFloat("ySpeed", ySpeed);
  }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "FallDeath") {
			Death ();
		} else if (other.tag == "ReaperDeath") {
			Death ();
		} else if (other.tag == "BoulderDeath") {
			Death ();
		} else if (other.tag == "Coin") {
            source.PlayOneShot(coin);
			Destroy (other.gameObject);
			coins += 1;
			coinCount.text = coins.ToString ();
		} else if (other.tag == "Finish") {
			Victory();
		}
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1.0f);
        if (dead) { SceneManager.LoadScene("Level 1"); } else { SceneManager.LoadScene("Main Menu"); }
    }
     

    public void Fade(Image img) {
        var tempColor = img.color;
        tempColor.a += (float) decrement;
        img.color = tempColor;
    }

	public void Death()
    {
        dead = true;
        if (b_img.color.a < 1.0f)
        {
            Fade(b_img);
        }
        StartCoroutine("Wait");
	}

    public void Victory()
    {
        win = true;
        if (w_img.color.a < 1.0f)
        {
            Fade(w_img);
        }
        StartCoroutine("Wait");
    }
}
