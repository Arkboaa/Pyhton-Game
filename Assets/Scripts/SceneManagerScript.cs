using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public TMP_InputField kodAlani; 

    public void SonrakiBolum()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void KodAlaniniTemizle()
    {
        if (kodAlani != null)
        {
            kodAlani.text = "";
        }
    }

    public void SahneyiYenidenBaslat()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}