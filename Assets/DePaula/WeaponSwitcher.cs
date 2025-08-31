using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] GameObject pistola;
    [SerializeField] GameObject ak;

    public void SwitchToAk()
    {
        //pistola.enabled = false;
        pistola.SetActive(false);
        ak.SetActive(true);
    }

    public Arco GetCurrentWeapon()
    {
        if (pistola.activeInHierarchy)
        {
            return pistola.GetComponent<Arco>();
        }
        else
        {
            return ak.GetComponent<Arco>();
        }
    }
}
