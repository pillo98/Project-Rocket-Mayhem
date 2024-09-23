using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject Shootable;
    [SerializeField] public float BulletSpeed = 10f;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private float cooldownTime = 5f;
    [SerializeField] private float lastUsedTime;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audio;
    void Update()
    {
    }
    [SerializeField] 
    private LayerMask LayersToHit;
    private void OnTriggerStay(Collider other)
    {
        CheackForHit(other);
    }

    private void CheackForHit(Collider Collider)
    {
        if (Collider.gameObject.CompareTag("Player") && Collider.gameObject.name == "PlayerCapsule")
        {

            RaycastHit hit;
            Vector3 vector3 = Collider.gameObject.transform.position - transform.position;
 
            if (Physics.Raycast(transform.position, vector3, out hit, Mathf.Infinity, LayersToHit, QueryTriggerInteraction.UseGlobal))
            {
                Debug.DrawRay(transform.position, Collider.gameObject.transform.position - transform.position, Color.yellow);
                Debug.Log("Did Hit");
                if (hit.collider.gameObject.CompareTag("Player"))
                { 
                    this.transform.LookAt(Collider.transform);
                    Shoot();
                }

            }
            else
            {
                Debug.DrawRay(transform.position, Collider.gameObject.transform.position - transform.position, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }

    private void Shoot()
    {

        if (Time.time > lastUsedTime + cooldownTime)
        {
            audioSource.PlayOneShot(audio);
            animator.Play("EnemyBlink");

            GameObject newRocket = Instantiate(Shootable, BulletSpawn.position, BulletSpawn.rotation);

            Rigidbody rb = newRocket.GetComponent<Rigidbody>();
            
            rb.velocity = BulletSpawn.forward * BulletSpeed;



            lastUsedTime = Time.time;
        }
    }
}