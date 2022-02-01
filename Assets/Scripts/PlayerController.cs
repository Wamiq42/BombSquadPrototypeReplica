using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float rotationSpeed;
    public float horizontalInput;
    public float verticalInput;
    public Rigidbody playerRb;
    public bool isStickyBombPicked = false;
    public bool isMultiplerPicked = false;


    private int PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (PlayerHealth <= 0)
            Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("StickyBomb"))
        {
            isStickyBombPicked = true;
            StartCoroutine(StickyBombPower());
            Destroy(other.gameObject);
        }
        if (other.CompareTag("MultiplyBombs"))
        {
            isMultiplerPicked = true;
            StartCoroutine(StickyBombPower());
            Destroy(other.gameObject);
        }
        if(other.CompareTag("HealthPotion"))
        {
            setHealth(+10);
            Destroy(other.gameObject);
        }
    }

    IEnumerator StickyBombPower()
    {
        yield return new WaitForSeconds(7);
        if (isStickyBombPicked)
            isStickyBombPicked = false;
        else if (isMultiplerPicked)
            isMultiplerPicked = false;
    }


    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
    }

    public void setHealth(int health)
    {
        PlayerHealth += health;
        Debug.Log("PlayerHealth");
    }

}
