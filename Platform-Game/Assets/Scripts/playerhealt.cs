using UnityEngine;
using System.Collections; 

public class playerhealth : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRend; 
    private AudioSource audioSource;   

    private bool olduMu = false;

    [Header("Ölüm Efektleri")]
    public AudioClip olumSesi; 
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap") && !olduMu)
        {
            Ol();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !olduMu)
        {
            Ol();
        }
    }

    void Ol()
    {
        olduMu = true;
        Debug.Log("Karakter Öldü!");
        GetComponent<playermovement>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("die");
        if (olumSesi != null)
        {
           
            AudioSource.PlayClipAtPoint(olumSesi, Camera.main.transform.position, 2f);
        }

        
        StartCoroutine(KirmiziYanSon());//bekletme yapar
        GameManager manager = FindFirstObjectByType<GameManager>();

        if (manager != null)
        {
            manager.OyuncuOldu();
        }

        
    }

    
    IEnumerator KirmiziYanSon() //parçalý fonk
    {
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(0.5f);
        spriteRend.color = Color.white;
    }
}