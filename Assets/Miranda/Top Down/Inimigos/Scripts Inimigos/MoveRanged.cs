using UnityEngine;

public class MoveRanged : MonoBehaviour
{
    [SerializeField]public float shootingRange = 5f;
    public GameObject bullet;
    public GameObject bulletParent;
    Transform target;
}
