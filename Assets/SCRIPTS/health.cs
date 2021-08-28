using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour{

    public GameObject health_counter;
    public int current_health = 50;

    //metodi Unity
    private void Awake() {
        health_counter = GameObject.FindGameObjectWithTag("health_counter");
    }
    void Start(){
        updateHealthCounter();
    }
    void Update() {
        if ( !(getHealth() > 0) ) {
            Debug.Log("Game over");
            //TODO game manager
        }
    }
    public int getHealth() {
        return this.current_health;
    }
    //aggiorna contatore salute
    private void updateHealthCounter() {
        this.health_counter.GetComponent<Text>().text = "" + getHealth();
    }
    //toglie salute
    public void takeDamage(int x) {
        if (getHealth() < x) {
            //GAME OVER
        }else { 
            this.current_health -= x;
            updateHealthCounter();
        }
    }
    //aggiunge salute
    public void healBy(int x) {
        if( getHealth() + x > 100) {
            this.current_health = 100;
        }else { 
            this.current_health += x;
        }
        updateHealthCounter();
    }
}
