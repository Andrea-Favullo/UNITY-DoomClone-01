using UnityEngine;

public class mouse_look : MonoBehaviour{

    public float mouse_sensitivity = 100f;
    public Transform player_body;

    private float x_rotation = 0f;

    private void Awake() {
        player_body = GameObject.FindGameObjectWithTag("player").transform;
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);

    }
}
