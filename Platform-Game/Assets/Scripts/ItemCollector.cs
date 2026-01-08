using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [Header("Ses Ayarlarý")]
    public AudioClip toplamaSesi; 
    [Range(0, 5f)] public float sesSiddeti = 1f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (toplamaSesi != null)
            {
                AudioSource.PlayClipAtPoint(toplamaSesi, Camera.main.transform.position, sesSiddeti);
                //AudioSource.PlayClipAtPoint(toplamaSesi, transform.position, sesSiddeti);
            }

           
            GameManager manager = FindFirstObjectByType<GameManager>();

            if (manager != null)
            {
                manager.MantarEkle();
            }
            
            

            Debug.Log("Mantar Toplandý!");

            
            Destroy(gameObject);
        }
    }
}