using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [Header("AMMUS")]

    [SerializeField] private GameObject Rocket;
    [SerializeField] public float BulletSpeed = 10f;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private GameObject RocetOnGun;
    [SerializeField] private float cooldownTime = 5f;
    [SerializeField] private float lastUsedTime;
    [SerializeField] private GameObject RPG;
    [SerializeField] private Animator RPGShoot;
    [SerializeField]
    private PauseManager PauseManager;

    private void Awake()
    {
        RPGShoot = RPG.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > lastUsedTime + cooldownTime && PauseManager.GamePaused == false)
        {

            GameObject newRocket = Instantiate(Rocket, BulletSpawn.position, BulletSpawn.rotation );

            Rigidbody rb = newRocket.GetComponent<Rigidbody>();

            rb.velocity = BulletSpawn.right * BulletSpeed;

            RocetOnGun.SetActive(false);

            RPGShoot.Play("Shoot");

            lastUsedTime = Time.time;
        }
        if(Time.time > lastUsedTime + cooldownTime )
        {
            RocetOnGun.SetActive(true);
        }   
    }

}
