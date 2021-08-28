using UnityEngine;

public class enemy_actions : MonoBehaviour{

    public int health;
    public int current_health;
    public float damage;

    void Start(){
    }

    void Update(){
        bool is_half_health = getCurrentHealth() == (getHealth() / 2f);
        is_half_health = false;
        if ( is_half_health ) {
            Debug.Log("Change in color");
            this.GetComponentInParent<Material>().SetColor("test", new Color(255f, 255f, 0f));
        }
    }

    public int getCurrentHealth() {
        return this.current_health;
    }

    public int getHealth() {
        return this.health;
    }

    public void setCurrentHealth(int hp) {
        this.current_health += hp;
        Debug.Log("Enemy Health: " + getCurrentHealth());
    }

    /// <summary>
    /// true -> the enemy would die,
    /// false -> it wouldn't
    /// </summary>
    public bool check_health(float d) { 
        return getCurrentHealth() - d <= 0;
    }

}
