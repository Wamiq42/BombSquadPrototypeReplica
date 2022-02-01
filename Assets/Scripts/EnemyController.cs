using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    private Vector3 direction;

    private int enemyHealth;

    void Start()
    {
        enemyHealth = 100;
        player = GameObject.Find("Player");
    }

    void Update()
    {
            EnemyMovement();
        if (enemyHealth <= 0)
            Destroy(gameObject);    
    }




    /*
     * METHODSSSSSSSSSSS
     * 
     */

    void EnemyMovement()
    {

        transform.LookAt(player.transform);
        Debug.Log(Direction());
        transform.Translate(Direction() * 5 * Time.deltaTime);
    }

    Vector3 Direction()
    {
        direction = (transform.position - player.transform.position).normalized;
        return direction;
    }

    public void setHealth(int health)
    {
        enemyHealth += health;
        Debug.Log("EnemyHealth" + enemyHealth);
    }
}
