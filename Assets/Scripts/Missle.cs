using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;

    // Start is called before the first frame update
    //starts a coroutine called deathTimer
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    // Update is called once per frame
    //move the missile forward at speed multiplied by the time between frames
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //sets a timer on the missle to self destruct after 10 seconds
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
