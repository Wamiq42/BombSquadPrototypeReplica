using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBombBehaviour : MonoBehaviour
{
    public Rigidbody stickyBombRb;
    public float time = 1.5f;
    public ParticleSystem explosionSystem;

    private GameObject player;
    private GameObject[] enemy;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(Explode());

        if (transform.position.y < -2)
            Destroy(gameObject);

    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3.0f);
        explosionSystem.Play();
        if (player != null)
            DamagingHealth();
        if (enemy != null)
            EnemyDamage();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        stickyBombRb.isKinematic = false;
        //Destroy(gameObject);
    }

    void DamagingHealth()
    {

        if (Vector3.Distance(player.transform.position, transform.position) > -3
            && Vector3.Distance(player.transform.position, transform.position) < 3)
            player.GetComponent<PlayerController>().setHealth(-40);


    }

    void EnemyDamage()
    {
       
        for (int i = 0; i < enemy.Length; i++)
        {
            if (Vector3.Distance(enemy[i].transform.position, transform.position) > -3
                && Vector3.Distance(enemy[i].transform.position, transform.position) < 3)
                enemy[i].GetComponent<EnemyController>().setHealth(-40);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        stickyBombRb.isKinematic = true;
        transform.parent = collision.gameObject.transform;
    }
}
