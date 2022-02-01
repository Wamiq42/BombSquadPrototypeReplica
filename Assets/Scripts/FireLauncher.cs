using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLauncher : MonoBehaviour
{
    public GameObject[] Bombs; //0 index => normal bomb; 1 index => StickyBomb;
    public bool normalbombThrown = false;
    public GameObject Player;
    public Transform equipPoint;

    private GameObject bombLaunched;
    private float launchVelocity = 400f;
    private float timer = 0;
    private int thrownBalls = 0;
    private Vector3 positionSpawn;
    private PlayerController playerController;
   
   
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
            NormalBombSpawner();
            StickyBombSpawner();
            MultiplerBombSpawner();
    }

    void MultiplerBombSpawner()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerController.isMultiplerPicked && thrownBalls <4)
        {
            thrownBalls++;
            positionSpawn = transform.position + new Vector3(0, 0, 1f);
            bombLaunched = Instantiate(Bombs[0], positionSpawn, Bombs[0].transform.rotation);
            bombLaunched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, launchVelocity));
        }
    }


    void NormalBombSpawner()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !normalbombThrown && !playerController.isStickyBombPicked)
        {
            normalbombThrown = true;
            positionSpawn = transform.position + new Vector3(0, 0, 1f);
            bombLaunched = Instantiate(Bombs[0], transform.position, transform.rotation);
            bombLaunched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, launchVelocity));
        }
        if (bombLaunched == null)
        {
            normalbombThrown = false;
        }
    }
    void StickyBombSpawner()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerController.isStickyBombPicked)
        {
            positionSpawn = transform.position + new Vector3(0, 0, 1f);
            bombLaunched = Instantiate(Bombs[1], positionSpawn, transform.rotation);
            bombLaunched.transform.LookAt(GameObject.FindGameObjectWithTag("Enemy").transform.position);
            bombLaunched.GetComponent<Rigidbody>().AddRelativeForce(0, launchVelocity, launchVelocity);
           

        }
    }

 
}
