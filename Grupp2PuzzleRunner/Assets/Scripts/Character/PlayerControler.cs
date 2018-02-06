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

    float hitboxY;

    private Player player;
    private bool playerStop;
    bool crouch;

    void Start () {
        speed = defaultSpeed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        hitbox = GetComponentInChildren<BoxCollider2D>();
        ani = GetComponentInChildren<Animator>();
        playerStop = false;
        player = GetComponent<Player>();
        hitboxY = hitbox.size.y;
    }

    void Update()
    {
        //----------------------------------------RunRight------------------------------------
        if (!playerStop)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            ani.SetBool(runStateHash, true);
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
                hitbox.size = new Vector2(hitbox.size.x, hitboxY / 1.5f);
            }

            if (Input.GetButtonUp(player.B()) && grounded) //LeftShift and B to crouch.
            {
                ani.SetTrigger(crouchStateHash);
                ani.SetBool(crouchStateHash, false);
                hitbox.size = new Vector2(hitbox.size.x, hitboxY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    public void SetPlayerStartStop(bool f)
    {
        playerStop = f;
        if (f)
        {
            ani.SetBool(idleStateHash, true);
            ani.SetBool(runStateHash, false);
        } else
        {
            ani.SetBool(idleStateHash, false);
            ani.SetBool(runStateHash, true);
        }
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
}
