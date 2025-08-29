using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Inimigos", menuName = "Scriptable Objects/Inimigos")]
public class Inimigos : ScriptableObject
{
    [Header("Inimigo Melee")]
    public float meleeMaxHealth;
    public float meleeMoveSpeed;
    public float meleeDano;
   

    [Header("Inimigo Tank")]
    public float tankMaxHealth;
    public float shieldMaxHealth;
    public float tankMoveSpeed;
    public float tankDano;
    

    [Header("Inimigo Ranged")]
    public float rangedMaxHealth;
    public float rangedMoveSpeed;
    public float rangedDano;
    
}
