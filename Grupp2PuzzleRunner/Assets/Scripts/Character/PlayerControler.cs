using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    float defaultSpeed;
    float speed;
    [SerializeField]
    float jumpSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator ani;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Run");
    int idleStateHash = Animator.StringToHash("Idle");
    int crouchStateHash = Animator.StringToHash("IsCrouched");

    private Player player;
    private bool PlayerStop;

    void Start () {
        speed = defaultSpeed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        PlayerStop = true;
    }
	
	void Update () {
        //----------------------------------------RunRight------------------------------------
        if (PlayerStop)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
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
        if (Input.GetKey(KeyCode.Joystick1Button1) && gameObject.transform.position.y < 0 && PlayerStop  ||
            Input.GetKey(KeyCode.LeftShift) && gameObject.transform.position.y < 0 && PlayerStop ) //LeftShift and B to crouch.
        {
            ani.SetBool(crouchStateHash, true);       
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button1) && gameObject.transform.position.y < 0 && PlayerStop ||
            Input.GetKeyUp(KeyCode.LeftShift) && gameObject.transform.position.y < 0 && PlayerStop) //LeftShift and B to crouch.
        {
            ani.SetBool(crouchStateHash, false);
        }
    }
    
    public void SetPlayerStartStop()
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
