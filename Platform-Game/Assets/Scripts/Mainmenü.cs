using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçişi

public class MainMenu : MonoBehaviour
{
    public void OyunuBaslat()
    {
        SceneManager.LoadScene(1);
    }

   
    /*public void OyundanCik()
    {
        Debug.Log("Oyundan çıkıldı!");
        Application.Quit();
    }*/
}