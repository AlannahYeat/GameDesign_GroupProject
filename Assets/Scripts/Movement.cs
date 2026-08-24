using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public float health = 10; 
    public int coins; 
    public int lives =3; 
    public float gravity; 
    public float speed = 4;
    public float terminalVelocity;
    
    private float xDirection;
    private float yDirection;
    private Vector3 movement; 


    //tracks our up/dowm movement based on jumping 
    private float yVelocity;

    // Update is called once per frame
    void Update()
    {

        TakeDamage(10 * Time.deltaTime);
        // get our left/right input
        xDirection = Input.GetAxis("Horizontal");
        // get our up/down input
        yDirection = Input.GetAxis("Vertical");
        // give our directions to the movement vector, increased by speed
        movement = new Vector3(xDirection,0, yDirection);
        movement *= speed;

        //if we are on the ground...
        if(GetComponent<CharacterController>(). isGrounded)
        {

            yVelocity = -1; 
            //if we press the jump button
            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jumping!");
                //change out yvelocity based on the jump power
                yVelocity = jumpPower;
            }
        }
        //else if we are not on the ground 
        else
        {
            // make sue yvelocity is faster than terminal velocity
            // negative bc we are moving down 
            yVelocity = Mathf.Max(yVelocity, -terminalVelocity);
        }

        //apply gravity to gradually pull us downwards 
        yVelocity -= gravity * Time.deltaTime;

        movement.y = yVelocity;

        //make our whole movement occur over time
        movement *= Time.deltaTime; 

    // get the character controller and move using our input  
    GetComponent<CharacterController>().Move(movement);  

    }
    // amount will be provided whe we run this function 
    public void TakeDamage(float amount)
    {
        //Reduce health by incoming amount 
        health -= amount; 
        // if health is less than or equal to 0 
        if (health <= 0)
        {
           // reduce lives by one 
           lives -= 1; 
            // set health back to 100
            health = 10; 
        }    
    }
}
