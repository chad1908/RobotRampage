using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Robot : MonoBehaviour
{
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private AudioClip weakHitSound;
    [SerializeField]
    private string robotType;
    [SerializeField]
    GameObject missileprefab;

    public Animator robot;
    public int health;
    public int range;
    public float fireRate;
    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float timeLastFired;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //sets the agent and player values to the navmesh agent and player componenets.
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the robot is dead before starting.
        if (isDead)
        {
            return;
        }

        //makes the robot face the player
        transform.LookAt(player);
        //tells the robot to use the navmesh to find the player.
        agent.SetDestination(player.position);
        //check to see if the robot is within firing range and if there’s been enough time between shots to fire again.
        if (Vector3.Distance(transform.position, player.position) < range
        && Time.time - timeLastFired > fireRate)
        {
            //update timeLastFired to the current time and call Fire(), which simply logs a message to the console for the time being.
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire()
    {
        GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
        GetComponent<AudioSource>().PlayOneShot(fireSound);
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        health -= amount;

        if (health <= 0)
        {
            isDead = true;
            robot.Play("Die");
            StartCoroutine("DestroyRobot");
            Game.RemoveEnemy();
            GetComponent<AudioSource>().PlayOneShot(deathSound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(weakHitSound);
        }

        IEnumerator DestroyRobot()
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }

    }
    IEnumerator DestroyRobot()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
