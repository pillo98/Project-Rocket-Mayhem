using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [Header("AMMUS")]

    [SerializeField] private GameObject Rocket;
    [SerializeField] private float BulletSpeed = 10f;
    [SerializeField] private Transform BulletSpawn;

    public bool IsShooting { get; set; }

    private Mouse mouse;

    private void Start()
    {
        mouse = Mouse.current;
    }

    private void Update()
    {
        IsShooting = mouse.leftButton.wasPressedThisFrame;
    }

    private void FixedUpdate()
    {
        if(IsShooting)
        {
            GameObject newRocket = Instantiate(Rocket, BulletSpawn.position, BulletSpawn.rotation);

            Rigidbody rb = newRocket.GetComponent<Rigidbody>();

            rb.velocity = BulletSpawn.forward * BulletSpeed;
        }
        IsShooting = false;
    }

}
