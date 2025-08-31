using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;


public class ShooterFinal : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    
    public Vector3  local;
    private Transform player, target;
    public Explosao explosão;
    public Inimigos inimigos;



    [SerializeField] private float shootRate;
    [SerializeField] private float projectileMaxMoveSpeed = 2f;
    [SerializeField] private float projectileMaxHeight = 2f;


    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    [SerializeField] private AnimationCurve projectileSpeedAnimationCurve;


    private float shootTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        shootRate = inimigos.rangedFireRate;
    }
    public void Atirar()
    {
        shootTimer -= Time.deltaTime;


        if (shootTimer <= 0)
        {
            shootTimer = shootRate;
            local = player.position;
            explosão.LocalExplosão(local);
            target = GameObject.FindGameObjectWithTag("explosion").GetComponent<Transform>();

            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            


            projectile.InitializeProjectile(target, projectileMaxMoveSpeed, projectileMaxHeight);
            projectile.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
            
            
        }
    }
}
