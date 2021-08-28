using UnityEngine;

public class look_player : MonoBehaviour{

    public new GameObject camera;

    private void Awake() {
        camera = GameObject.FindWithTag("MainCamera");
    }

    void Update(){
        Quaternion player_rotation = camera.transform.rotation;
        this.transform.rotation = player_rotation;
    }
}
