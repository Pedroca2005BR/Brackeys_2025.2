using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CookieAltar : MonoBehaviour
{
    [SerializeField] GameObject altarComCookie;
    [SerializeField] GameObject altarDescoocado;
    public void EatTheCookie()
    {
        SoundManager.PlaySound(SoundType.COMER);
        WaveSpawner.instance.SpawnNextWave();
        //Destroy(gameObject);
        altarComCookie.SetActive(false);
        altarDescoocado.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EatTheCookie();
        }
    }
}
