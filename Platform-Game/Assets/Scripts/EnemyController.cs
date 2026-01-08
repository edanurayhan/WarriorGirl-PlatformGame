using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    public float savurmaGucu = 5f;
    public int hasarMiktari = 1;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Karakter Düþmana Çarptý!");

            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                 //Karakteri çarptýðý yönün tersine fýrlat (Sarsma efekti)
                Vector2 savurmaYonu = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(savurmaYonu * savurmaGucu, ForceMode2D.Impulse);
            }

        }
    }
}