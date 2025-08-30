using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShooterFinal : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private Transform target;


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
    private void Update()
    {
        shootTimer -= Time.deltaTime;


        if (shootTimer <= 0)
        {
            shootTimer = shootRate;
            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();


            projectile.InitializeProjectile(target, projectileMaxMoveSpeed, projectileMaxHeight);
            projectile.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
        }
    }
}
