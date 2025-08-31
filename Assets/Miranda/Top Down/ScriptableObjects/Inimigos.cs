using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Inimigos", menuName = "Scriptable Objects/Inimigos")]
public class Inimigos : ScriptableObject
{
    [Header("Inimigo Melee")]
    public float meleeMaxHealth; // vida
    public float meleeMoveSpeed; // velocidade de movimento
    public float meleeDano; // dano no collision


    [Header("Inimigo Tank")]
    public float tankMaxHealth; // vida
    public float shieldMaxHealth; // vida do escudo
    public float tankMoveSpeed; // velocidade de movimento
    public float tankDano; // dano no collision
    

    [Header("Inimigo Ranged")]
    public float rangedMaxHealth; // vida
    public float rangedMoveSpeed; // velocidade de movimento
    public float rangedFireRate; // velocidade que o inimigo joga um projetil em segundos
    public float rangedAttackRange; // distância que o inimigo pode atirar
    public float splashRange; // raio da explosão   
    public float rangedDano; // dano no collision da explosão

}
