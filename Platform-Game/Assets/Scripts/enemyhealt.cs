using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header("Can Ayarlarý")]
    public int maxCan = 3;
    private int guncelCan;

    [Header("Görsel Efektler")]
    public GameObject olumEfekti;
    private SpriteRenderer spriteRend;

    [Header("Ses Efektleri ve Ayarlarý")]
    public AudioClip hasarSesi;
    [Range(0, 1f)] public float hasarSesiSiddeti = 1f; 

    public AudioClip olumSesi;
    [Range(0, 1f)] public float olumSesiSiddeti = 1f; 

    private AudioSource audioSource;

    void Start()
    {
        guncelCan = maxCan;
        spriteRend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void HasarAl(int hasarMiktari)
    {
        guncelCan -= hasarMiktari;

        StartCoroutine(KirmiziYanSon());

        if (audioSource != null && hasarSesi != null)
        {
            
            AudioSource.PlayClipAtPoint(hasarSesi, Camera.main.transform.position, hasarSesiSiddeti);
            //audioSource.PlayOneShot(hasarSesi, hasarSesiSiddeti);
        }

        if (guncelCan <= 0)
        {
            Ol();
        }
    }

    IEnumerator KirmiziYanSon()
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = Color.white;
    }

    void Ol()
    {
        if (olumEfekti != null)
        {
            Instantiate(olumEfekti, transform.position, Quaternion.identity); //prefab kullanýmý
        }

        if (olumSesi != null)
        {
            
            AudioSource.PlayClipAtPoint(olumSesi, Camera.main.transform.position, olumSesiSiddeti);
            //AudioSource.PlayClipAtPoint(olumSesi, transform.position, olumSesiSiddeti);
        }

        
        FindFirstObjectByType<GameManager>().DusmanEkle();
        
        Destroy(gameObject);
    }
}