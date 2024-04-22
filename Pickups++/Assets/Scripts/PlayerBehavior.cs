using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;


public class PlayerBehavior : MonoBehaviour
{
    
    public GameBehavior gameManager;
    public GunAnims gunAnims;
    public GameObject gun;
    public GameObject flashlight;
    public Light flashlightLight;
    public GameObject key;
    public GameObject flashLightCollider;
    

    public float moveSpeed = 10f;

    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;

    public int ammo = 0;

    private Rigidbody _rb;

    private bool canShoot = false;
    private bool canJump = false;
    private bool gunIsOut = false;
    public bool hasGun = false;
    private bool flashlightIsOut = false;
    public bool hasFlashlight = false;
    public bool flashlightIsOn = false;
    public bool keyIsOut = false;
    public bool hasKey = false;

    float cooldownTimestamp = 0f;
    [SerializeField] float cooldown = 0.5f;


    public bool invertCamera = false;
    public bool cameraCanMove = true;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;

    public Camera Main_Camera;

    private Animator Animator;

    public bool lockCursor = true;

    private CapsuleCollider _col;
    

    // Internal Variables
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Image crosshairObject;

    public bool playerCanMove = true;
   

    // Start is called before the first frame update
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        _col = GetComponent<CapsuleCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        
        if(Input.GetMouseButtonDown(0) && gunIsOut)
        {
            canShoot = true;
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            canJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasGun)
        {
            if(gunIsOut)
            {
                gun.SetActive(false);
                gunIsOut = false;
            }
            else if (flashlightIsOut && hasFlashlight)
            {
                flashlight.SetActive(false);
                flashlightIsOut = false;
                gun.SetActive(true);
                gunIsOut = true;
            }
            else if (keyIsOut && hasKey)
            {
                key.SetActive(false);
                keyIsOut = false;
                gun.SetActive(true);
                gunIsOut = true;
            }
            else
            {
                gunIsOut = true;
                flashlightIsOut = false;
                keyIsOut = false;
                gun.SetActive(true);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && hasFlashlight)
        {
            if (flashlightIsOut)
            {
                flashlight.SetActive(false);
                flashlightIsOut = false;
                flashlightIsOn = false;
            }
            else if (gunIsOut && hasGun)
            {
                gun.SetActive(false);
                gunIsOut = false;
                flashlight.SetActive(true);
                flashlightIsOut = true;
                flashlightIsOn = true;
            }
            else if (keyIsOut && hasKey)
            {
                key.SetActive(false);
                keyIsOut = false;
                flashlight.SetActive(true);
                flashlightIsOut = true;
                flashlightIsOn = true;
            }
            else
            {
                flashlightIsOut = true;
                keyIsOut = false;
                gunIsOut = false;
                flashlight.SetActive(true);
                flashlightIsOn = true;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && hasKey)
        {
            if (keyIsOut)
            {
                key.SetActive(false);
                keyIsOut = false;
            }
            else if (gunIsOut && hasGun)
            {
                gun.SetActive(false);
                gunIsOut = false;
                key.SetActive(true);
                keyIsOut = true;

            }
            else if (flashlightIsOut && hasFlashlight)
            {
                flashlight.SetActive(false);
                flashlightIsOut = false;
                key.SetActive(true);
                keyIsOut = true;
            }
            else
            {
                keyIsOut = true;
                flashlightIsOut = false;
                gunIsOut = false;
                key.SetActive(true);
            }
            
        }
        if (!hasKey && keyIsOut)
        {
            key.SetActive(false);
            keyIsOut = false;
        }
        if (Input.GetMouseButtonDown(0) && flashlightIsOut)
        {
            if (flashlightIsOn)
            {
                flashlightLight.intensity = 0;
                flashlightIsOn = false;
                flashlight.GetComponent<AudioSource>().Play();
                //flashLightCollider.SetActive(false);
            }
                
            else
            {
                flashlightLight.intensity = 20;
                flashlightIsOn = true;
                flashlight.GetComponent<AudioSource>().Play();
                //flashLightCollider.SetActive(true);

            }
                
        }
        

        if (cameraCanMove)
        {
            yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

            if (!invertCamera)
            {
                pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
            }
            else
            {
                // Inverted Y
                pitch += mouseSensitivity * Input.GetAxis("Mouse Y");
            }

            // Clamp pitch between lookAngle
            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

            transform.localEulerAngles = new Vector3(0, yaw, 0);
            Main_Camera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.HP -= 1;
            collision.gameObject.SetActive(false);
            
        }
        
    }

    void FixedUpdate()
    {

        if (canJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            canJump = false;
            
        }

        if (canShoot)
        {
            tryShoot();
        }
        

        _rb = GetComponent<Rigidbody>();
        if(playerCanMove)
            _rb.MovePosition(transform.position + (transform.forward * vInput + this.transform.right * hInput) * Time.fixedDeltaTime);
    }
    private bool isGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void tryShoot()
    {
        if (Time.time > cooldownTimestamp)
        {
            cooldownTimestamp = Time.time + cooldown;
            Shoot();
        }
        else
        {
            canShoot = false;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, Main_Camera.transform.position + Main_Camera.transform.forward, this.transform.rotation) as GameObject;
        newBullet.transform.eulerAngles = new Vector3(Main_Camera.transform.rotation.x, this.transform.rotation.y);
        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = Main_Camera.transform.forward * bulletSpeed;
        canShoot = false;

        //Shooting animation
        gunAnims.Shoot();

    }
    
}
