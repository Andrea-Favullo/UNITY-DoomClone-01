using UnityEngine;
using UnityEngine.UI;

public class player_actions : MonoBehaviour{

    public gun gun;
    public health health;

    public AudioSource ammo_pickup_sfx;
    public AudioSource health_pickup_sfx;

    private void Start() {
        gun = GameObject.FindGameObjectWithTag("weapon").GetComponent<gun>();
        health = GameObject.FindGameObjectWithTag("health").GetComponent<health>();
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "ammo_drop") {
            if( gun.shots < 99) {
                ammo_pickup_sfx.Play();
                gun.changeAmmoBy(10);
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "health_drop") {
            if (health.getHealth() < 100) {
                health_pickup_sfx.Play();
                health.healBy(15);
                Destroy(other.gameObject);
            }
        }
    }

}
