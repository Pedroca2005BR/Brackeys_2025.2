using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShooterFinal : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    public Vector2  local;
    private Transform target;
    public Explosão explosão;


    [SerializeField] private float shootRate = 1f;
    [SerializeField] private float projectileMaxMoveSpeed = 2f;
    [SerializeField] private float projectileMaxHeight = 2f;


    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    [SerializeField] private AnimationCurve projectileSpeedAnimationCurve;


    private float shootTimer;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void Atirar()
    {
        shootTimer -= Time.deltaTime;


        if (shootTimer <= 0)
        {
            shootTimer = shootRate;
            local = target.position;
            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();


            projectile.InitializeProjectile(target, projectileMaxMoveSpeed, projectileMaxHeight);
            projectile.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
            
            explosão.LocalExplosão(local);
        }
    }
}
