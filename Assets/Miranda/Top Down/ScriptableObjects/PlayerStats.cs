using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Movimentação")]
    public float[] maxHealth; // Vida maxima
    public float[] moveSpeed; // Velocidade de movimento do jogador

    [Header("Dash")]
    public float[] dashDistance; // Na verdade muda a velocidade do dash mas é mais facil pensar como distancia ja que ele vai seguir para uma direção mais rapido mas ficara preso no estado de dash pela mesma quantidade de tempo
    public float[] dashCooldown; // Cooldown do dash em segundos
    

    [Header("Projeteis")]
    public int[] projectileDamage; // Dano do projétil
    public float[] shotCooldown;

    [Header("AK")]
    public float akShotCooldownMultiplier;
    public float akSpreadAngle;
    public float akDamageMultiplier;

}
