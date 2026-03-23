using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    //Player Movement Componants 
    private CharacterController controller;
    private Animator animator;


    private float moveSpeed = 2f;

    [Header("Movement System")]
    public float walkspeed = 2f;
    public float runspeed = 4f;

    //a start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    // an update is called once per frame
    void Update()
    {
        //runs the function that handle the movelment of the player
        Move();

    }

    public void Move()
    {
        //gets the horizontal and vertical input from the player as a number
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        //Check if shift key is pressed
        if (Input.GetButton("Sprint"))
        {
            //if so, set thewe animation to run and increase the movespeed
            moveSpeed = runspeed;
        
        }else
        { //set the animation to walk and decrease the movespeed
            moveSpeed = walkspeed; 
        }


        //check if there is movement input
        if (dir.magnitude >= 0.1f)
        {
            // If there is movement, look towards that direction and move
            transform.rotation = Quaternion.LookRotation(dir);

            //Movement of the player
            controller.Move(velocity);

        }
        animator.SetFloat("speed", velocity.magnitude);
    }
}
