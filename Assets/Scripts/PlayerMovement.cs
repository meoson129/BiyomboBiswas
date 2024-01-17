using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float speedBoost = 1f;
    public Transform teleportDest;
    public AudioSource keyPickUp;
    public AudioSource wallBroken;
    public AudioSource wallBump;
    public AudioSource avocado;
    public AudioSource jumpSound;
    public AudioSource teleportSound;

    private bool isGround = true;
    private bool isRed = false;

    private List<string> keysCollected = new List<string>();
    private Vector3 movementStorage;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    

    void Start()
    {
        //Physics.gravity = new Vector3(0, -5, 0);
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(isGround);
        if (Input.GetKeyDown(KeyCode.Space) && (isGround == true || isRed == true))
        {
            Jump();
            isGround = false;
        }
    }

    

    void FixedUpdate()
    {
        if (Time.timeScale > 0f)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            m_Movement.Set(horizontal, 0f, vertical);
            m_Movement.Normalize();

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsWalking", isWalking);

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);

            

            

            
            movementStorage = m_Movement;
            
        }

        
       
    }

    

    void Jump()
    {
        m_Rigidbody.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
        m_Animator.SetBool("IsJumping", true);
        jumpSound.Play();
    }

    void OnAnimatorMove()
    {      
            m_Rigidbody.MovePosition(m_Rigidbody.position + movementStorage * m_Animator.deltaPosition.magnitude * speedBoost);
            m_Rigidbody.MoveRotation(m_Rotation);
           
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keysCollected.Add(other.tag);
            Destroy(other.gameObject);
            keyPickUp.Play();
        }
        else if (other.CompareTag("Obstacle"))
        {
            if (HasKey())
            {
                Destroy(other.gameObject);
                keysCollected.RemoveAt(keysCollected.Count - 1);
                wallBroken.Play();
            }
            else
            {
                wallBump.Play();
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.CompareTag("GoodItem"))
        {
            setBoost(1.5f);
            Destroy(other.gameObject);
            avocado.Play();
        }
        else if (other.CompareTag("TeleporterDep"))
        {
            transform.position = teleportDest.position;
            teleportSound.Play();
        }
        else if (other.CompareTag("Ground"))
        {
            isGround = true;
        }
        else if (other.CompareTag("RedZone"))
        {
            setBoost(0.5f);
            isRed = true;

        }
    }

    void setBoost(float boostFactor)
    {
       
        speedBoost = boostFactor;
        
        
    }

    public bool HasKey()
    {
        return keysCollected.Count > 0;
    }

    public void AddKey()
    {
        keysCollected.Add("Key");
    }


}

