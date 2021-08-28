using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour {

    //attributi dell'arma
    public int shots = 20;
    public float damage = 25f;
    public float range = 100f;

    //altri oggetti
    public GameObject player;
    public GameObject shots_counter;
    public GameObject health_counter;
    public Camera fps_cam;

    //variabili di stato
    int i_reload = 0;
    bool is_reload_complete = false;
    bool is_reloading = false;
    bool is_shooting = false;

    //frame posizione arma
    public Sprite shot;
    public Sprite still;

    //frame animazione di ricarica
    public Sprite reload_0;
    public Sprite reload_1;
    public Sprite reload_2;
    public Sprite reload_3;
    public Sprite reload_4;
    public Sprite reload_5;
    public Sprite reload_6;
    public Sprite reload_7;
    public Sprite reload_8;
    public Sprite reload_9;

    //effetti sonori dell'arma
    public AudioSource shot_sfx;
    public AudioSource reload_sfx;
    public AudioSource empty_sfx;

    public GameObject enemy;

    private void Start() {
        updateAmmoCounter();
    }

    void Update(){
        //se il player ha sparato
        if (Input.GetButtonDown("Fire1")) {
            if (!this.isEmpty()) {
                if (!is_shooting && !is_reloading) {
                    shot_sfx.Play();
                    changeAmmoBy(-1);
                    updateAmmoCounter();
                    shoot();
                }
            }
            else {
                empty_sfx.Play();
            }
        }
        //ricarica
        if (Input.GetKeyDown(KeyCode.R)) {
            if (!is_reloading) {
                Debug.Log("Reloading..");
                reload_sfx.Play();
                reload();
            }

        }
        if (Input.GetKeyDown(KeyCode.E)) {
            //interaction with interactable world objects (doors, exit)
        }
    }

    public float getDamage() {
        return this.damage;
    }

    private void updateAmmoCounter() {
        this.shots_counter.GetComponent<Text>().text = "" + this.shots;
    }
    private bool isEmpty() {
        return this.shots < 1;
    }
    /// <summary>
    /// positive value -> increse ammo amount,
    /// negative value -> decrese ammo amount
    /// </summary>
    public void changeAmmoBy(int x) {
        if( this.shots+x > 99) {
            this.shots = 99;
        }else {
            this.shots += x;
        }
        
        updateAmmoCounter();
    }
    private void changeGunSprite(Sprite sprite) {
        this.GetComponent<Image>().sprite = sprite;
    }
    private void shoot() {
        is_shooting = true;
        RaycastHit hit;
        
        changeGunSprite(this.shot);
        
        Invoke("stayStill", 0.5f);

        if (Physics.Raycast(fps_cam.transform.position, fps_cam.transform.forward, out hit, range)) {
            
            Debug.Log(hit.transform.name);

            this.enemy = hit.transform.gameObject;

            if (hit.transform.tag == "Enemy") {

                GameObject enemy = hit.transform.gameObject;
                enemy_actions enemy_script = enemy.GetComponent<enemy_actions>();

                if (enemy_script.check_health( getDamage() )) {
                    Destroy(enemy);
                }else {
                    enemy_script.setCurrentHealth( -((int)getDamage()) );
                }
                
            }
        }
    }
    private void stayStill() {
        if (!is_reloading) {
            changeGunSprite(this.still);
        }
        is_shooting = false;
    }

    private void reload() {
        
        float reloading_offset = 0.1f;
        //stadi dell'animazione
        switch (i_reload) {
            case 0:
                i_reload++;
                is_reload_complete = false;
                is_reloading = true;
                changeGunSprite(this.reload_0);
                Invoke("reload", reloading_offset);
                break;
            case 1:
                i_reload++;
                changeGunSprite(this.reload_1);
                Invoke("reload", reloading_offset);
                break;
            case 2:
                i_reload++;
                changeGunSprite(this.reload_2);
                Invoke("reload", reloading_offset);
                break;
            case 3:
                i_reload++;
                changeGunSprite(this.reload_3);
                Invoke("reload", reloading_offset);
                break;
            case 4:
                i_reload++;
                changeGunSprite(this.reload_4);
                Invoke("reload", reloading_offset);
                break;
            case 5:
                i_reload++;
                changeGunSprite(this.reload_5);
                Invoke("reload", reloading_offset);
                break;
            case 6:
                i_reload++;
                changeGunSprite(this.reload_6);
                Invoke("reload", reloading_offset);
                break;
            case 7:
                i_reload++;
                changeGunSprite(this.reload_7);
                Invoke("reload", reloading_offset);
                break;
            case 8:
                i_reload++;
                changeGunSprite(this.reload_8);
                Invoke("reload", reloading_offset);
                break;
            //ultimo frame
            case 9:
                i_reload = 0;
                is_reload_complete = true;
                changeGunSprite(this.reload_9);
                break;

            default:
                break;
        }
        //se l'animazione è completa ...
        if (i_reload == 0 && is_reload_complete) { 

            Debug.Log("Reloading done");
            shots = 20;
            updateAmmoCounter();

            is_reloading = false;
            Invoke("stayStill", reloading_offset);
        }
    }

}
