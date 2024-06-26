using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public bool player1 = true;

    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public AudioClip vroom;
    public AudioClip bang;
    public AudioSource sound;
    [Header("UI")]
    public Transform healthBar;
    
    [Header("VFX")]
    public GameObject dustVFX;

    Rigidbody rb;
    Vector3 input = new Vector3();

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //InvokeRepeating(function name, time to start, repeat rate)
        InvokeRepeating(nameof(Fire), fireRate, fireRate);
        sound.PlayOneShot(vroom);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        sound.PlayOneShot(bang);
    }

    void Update()
    {
        if (player1)
        {
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrow");
            input.z = Input.GetAxis("VerticalArrow");
        }

        if (input != Vector3.zero)
        {
            transform.forward = input;
            
            //activate on movement
            if(!dustVFX.activeSelf) 
                dustVFX.SetActive(true);
        }
        else
        {
            if(dustVFX.activeSelf)
                dustVFX.SetActive(false);
        }
        
            
    }

    void FixedUpdate()
    {
        //input.y = rb.velocity.y;
        rb.velocity = input * speed + Vector3.up * rb.velocity.y;
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.localScale = new Vector3((float)currentHealth / maxHealth, 1, 1);
    }
}
