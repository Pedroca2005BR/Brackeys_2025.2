using Unity.Cinemachine;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public PlayerStats PlayerStats;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public Transform gun;
    public bool canFire, isAK; //Se o jogador pode atirar ou não
    private float timer;
    public float timeBetweenFiring = 5f;
    public float spreadAngle;
    float projectileSpeed = 10f;
    int cooldownLevel = 0, damageLevel = 0;

    private float distanceToCamera;
    private CinemachineBrain cameraBrain;

    void Start()
    {
        //cameraBrain = Camera.main.GetComponent<CinemachineBrain>();
        distanceToCamera = Vector3.Distance(transform.position, brain.ActiveVirtualCamera.VirtualCameraGameObject.transform.position);
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (isAK)
        {
            //timeBetweenFiring = PlayerStats.akShotCooldownMultiplier * PlayerStats.shotCooldown[cooldownLevel];
            spreadAngle = PlayerStats.akSpreadAngle;
        }

        AtualizarCooldown(0);
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        var direction = new Vector2(mousePos.x - gun.position.x, mousePos.y - gun.position.y);
        bulletTransform.right = direction;
        podeAtirar();

    }

    private void podeAtirar()
    {

        if (!canFire)
        {

            timer += Time.deltaTime;

            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

            if (Input.GetMouseButton(0) && canFire)
            {
            if (isAK)
            {
                
                canFire = false;// não permite o jogador atirar imediatamente
                Debug.Log("AK");

                gun.localRotation = Quaternion.Euler(new Vector3(bulletTransform.localRotation.x, bulletTransform.localRotation.y, Random.Range(-spreadAngle, spreadAngle)));
                GameObject bullet1 = Instantiate(bullet, gun.position, gun.rotation);
                bullet1.GetComponent<Arremesaveis>().Setup(isAK, damageLevel);
                bullet1.GetComponent<Rigidbody2D>().linearVelocity = gun.right * projectileSpeed;
                SoundManager.PlaySound(SoundType.TIRO);
                
            }
            else
            {
                Debug.Log("Pistola");

                canFire = false;// não permite o jogador atirar imediatamente
                GameObject bullet1 = Instantiate(bullet, gun.position, gun.rotation);
                bullet1.GetComponent<Arremesaveis>().Setup(isAK, damageLevel);
                bullet1.GetComponent<Rigidbody2D>().linearVelocity = gun.right * projectileSpeed;
                SoundManager.PlaySound(SoundType.TIRO);
            }
            
        }
        
    }

    public void AtualizarDano(int nivel)
    {
        damageLevel = nivel;
    }

    public void AtualizarCooldown(int nivel)
    {
        Debug.Log("Atualizando cooldown, ta" + nivel);
        cooldownLevel = nivel;

        if (isAK)
        {
            timeBetweenFiring = PlayerStats.akShotCooldownMultiplier * PlayerStats.shotCooldown[cooldownLevel];
        }
        else
        {
            timeBetweenFiring = PlayerStats.shotCooldown[cooldownLevel];
        }
    }
}
