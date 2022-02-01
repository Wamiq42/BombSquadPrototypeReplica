using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBomb : MonoBehaviour
{
    public float time = 1.5f;

    public ParticleSystem particleExplosion;
    private GameObject player;
    private GameObject[] enemy;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameObject != null) 
        StartCoroutine(Explode());

        if (transform.position.y < -4)
            Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        
       
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3.0f);
        particleExplosion.Play();
        if(player!=null)        
            DamagingHealth();
        if(enemy != null)
            EnemyDamage();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
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
}
