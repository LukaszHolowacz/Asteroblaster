using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
   

    #region Sigleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
 
    Rigidbody2D rigidBody2D;
    GameObject flame;
    GameObject impact02;
    Weapon currentWeapon;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        currentWeapon = gameObject.GetComponent<Weapon>();

        //Variables for flame object(image with animation) and death animation
        flame = GameObject.Find("flame");

        impact02 = GameObject.Find("Impact02");
        impact02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "DeathZone")
        {

            TakeDamage(1.0f);
            impact02.SetActive(true);

        }
        if (Health == 0)
        {
            TurnOffVisibility();
            SceneManager.LoadScene(4);
            KillPlayer();
            
        }
    }

    //Method killing the player and starting his respawn at original position
    void KillPlayer()
    {
        //Changing position of player and resetting his velocity
        transform.position = new Vector2(0f, 0f);
        rigidBody2D.velocity = Vector2.zero;
        rigidBody2D.angularVelocity = 0f;

        //Activating invcibility and invoking deactivation of his incibility
        TurnOffVisibility();
        Invoke("TurnOnVisibility", 6f);
    }

    //Changing layer of the player, so now he will be ignored by asteroids
    void TurnOffVisibility()
    {
        gameObject.layer = LayerMask.NameToLayer("IgnoreAsteroids");
    }

    //Changing layer of the player back to the original one, in which he can be killed again
    void TurnOnVisibility()
    {
        gameObject.layer = LayerMask.NameToLayer("Ship");
        impact02.SetActive(false);
    }
    

}

