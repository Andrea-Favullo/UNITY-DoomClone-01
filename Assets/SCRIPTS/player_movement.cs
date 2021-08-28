using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player_movement : MonoBehaviour{

    public CharacterController controller;
    public Transform ground_check; 
    public LayerMask ground_mask;
    public float speed = 12f;
    public float gravity = -20f;
    public float ground_distance = 9.4f;
    public float jump_height = 3f;

    bool is_grounded;
    Vector3 velocity;

    private void Awake() {
        controller = GameObject.FindGameObjectWithTag("player").GetComponent<CharacterController>();
        ground_check = GameObject.FindGameObjectWithTag("player_ground_check").transform;
        ground_mask = LayerMask.GetMask("Ground");
    }

    void Update(){
        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);
        if(is_grounded && velocity.y < 0) {
            velocity.y = -3f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && is_grounded) {
            velocity.y = Mathf.Sqrt(jump_height*-2f*gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
