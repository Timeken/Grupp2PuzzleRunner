using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    float defaultSpeed;
    float speed;
    [SerializeField]
    float jumpSpeed;
    bool grounded;

    private Rigidbody2D rigidbody2D;
    private Animator ani;
    private BoxCollider2D hitbox;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Run");
    int idleStateHash = Animator.StringToHash("Idle");
    int crouchStateHash = Animator.StringToHash("IsCrouched");

    private Player player;
<<<<<<< HEAD
    private bool playerStop;
=======
    private bool PlayerStop;
    bool crouch;
>>>>>>> 5d39ff18b0756a348d664bb8af94c1a104d7b309

    void Start () {
        speed = defaultSpeed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        hitbox = GetComponentInChildren<BoxCollider2D>();
        ani = GetComponentInChildren<Animator>();
<<<<<<< HEAD
        playerStop = false;
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (!playerStop)
=======
        PlayerStop = true;
        crouch = true;
    }
	
	void Update () {
        //----------------------------------------RunRight------------------------------------
        if (PlayerStop)
>>>>>>> 5d39ff18b0756a348d664bb8af94c1a104d7b309
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
<<<<<<< HEAD
            ani.SetTrigger(runStateHash);
            //----------------------------------------Jump------------------------------------
            if (Input.GetButtonDown(player.A()) && grounded) //Space and A to jump.
            {
                grounded = false;
                ani.SetTrigger(jumpHash);
                rigidbody2D.AddForce(Vector2.up * jumpSpeed);
            }
            //----------------------------------------Crouch------------------------------------
            if (Input.GetButtonDown(player.B()) && grounded) //LeftShift and B to crouch.
            {
                ani.SetBool(crouchStateHash, true);
            }

            if (Input.GetButtonUp(player.B()) && grounded) //LeftShift and B to crouch.
            {
                ani.SetTrigger(crouchStateHash);
                ani.SetBool(crouchStateHash, false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
=======
            ani.SetBool(runStateHash, true);
        }
        //----------------------------------------Jump------------------------------------
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && gameObject.transform.position.y < 0 && PlayerStop ||
            Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.y < 0 && PlayerStop) //Space and A to jump.
        {
            ani.SetTrigger(jumpHash);
            rigidbody2D.AddForce(Vector2.up * jumpSpeed);
        }
        //----------------------------------------Crouch------------------------------------
        if (Input.GetKey(KeyCode.Joystick1Button1) && PlayerStop  ||
            Input.GetKey(KeyCode.LeftShift) && PlayerStop ) //LeftShift and B to crouch.
        {
            if (crouch)
            {
                hitbox.size = new Vector2(hitbox.size.x, hitbox.size.y / 1.5f);
                crouch = false;
            }
            ani.SetBool(crouchStateHash, true);       
>>>>>>> 5d39ff18b0756a348d664bb8af94c1a104d7b309
        }
    }

<<<<<<< HEAD
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
=======
        if (Input.GetKeyUp(KeyCode.Joystick1Button1) && PlayerStop ||
            Input.GetKeyUp(KeyCode.LeftShift) && PlayerStop) //LeftShift and B to crouch.
        {
            if (!crouch)
            {
                hitbox.size = new Vector2(hitbox.size.x, hitbox.size.y * 1.5f);
                crouch = true;
            }
            ani.SetBool(crouchStateHash, false);
>>>>>>> 5d39ff18b0756a348d664bb8af94c1a104d7b309
        }
    }

    public void SetPlayerStartStop()
<<<<<<< HEAD
    {
        playerStop =! playerStop;
=======
    {    
        PlayerStop =! PlayerStop;
        ani.SetTrigger(idleStateHash);
        ani.SetBool(runStateHash, false);
        if (PlayerStop)
        {
            StartCoroutine(Delay());
        }
        StopCoroutine(Delay());
        print(PlayerStop);
>>>>>>> 5d39ff18b0756a348d664bb8af94c1a104d7b309
    }
    public void SetSpeed(float speed = 0)
    {
        if (speed == 0)
        {
            this.speed = defaultSpeed;
        }
        else
        {
            this.speed = speed;
        }
    }
    public bool Shortcut()
    {
        if (speed != defaultSpeed)
            return true;
        return false;
    }
    IEnumerator Delay()
    {
        ani.SetBool(runStateHash, true);
        yield return new WaitForSeconds(1);
        print("test2");
    }
}
