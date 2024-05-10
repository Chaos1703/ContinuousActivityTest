using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    public float speed = 8f;
    [HideInInspector]
    public Vector3 movement = Vector3.zero;
    private bool isJumping = false;
    private Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
            Jumping();
        }
        Movement();
    }

    void Movement(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(speed * moveHorizontal, rigidbody.velocity.y, speed * moveVertical);  

        if(joystick.Direction != Vector2.zero){
            rigidbody.velocity = new Vector3(joystick.Horizontal * speed , rigidbody.velocity.y, joystick.Vertical * speed);
        }

        //transform.position += movement * speed * Time.deltaTime;
    }

    public void Jumping(){
        rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        isJumping = true;
        if(TaskManager.instance.currentTask == Task3.instance){
            Task3.instance.numberOfJumps++;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground" && isJumping){
            isJumping = false;
        }
    }
}