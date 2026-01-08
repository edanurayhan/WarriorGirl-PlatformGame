using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    [Header("Game Over Yazýlarý")] 
    public Text mantarSkorText;
    public Text dusmanSkorText;

    [Header("Level Complete Yazýlarý")] 
    public Text winMantarText;   
    public Text winDusmanText;   

    
    private int toplananMantar = 0;
    private int olenDusman = 0;

   
    public void MantarEkle() { toplananMantar++; }
    public void DusmanEkle() { olenDusman++; }
    
    public void OyuncuOldu()
    {
        
        StartCoroutine(OyunBitisiBekle());
    }

    
    IEnumerator OyunBitisiBekle()
    {
        
        yield return new WaitForSeconds(1.1f);

        
        OyunuBitir();
    }
    public void OyunuBitir()
    {
        gameOverPanel.SetActive(true);
        mantarSkorText.text = "Toplanan Mantar: " + toplananMantar.ToString();
        dusmanSkorText.text = "Öldürülen Düþman: " + olenDusman.ToString();
        Time.timeScale = 0;
    }

    
    public void LeveliBitir()
    {
        levelCompletePanel.SetActive(true);
        winMantarText.text = "Toplanan Mantar: " + toplananMantar.ToString();
        winDusmanText.text = "Öldürülen Düþman: " + olenDusman.ToString();

        Time.timeScale = 0;
    }

    public void TekrarBaslat()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SonrakiLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}