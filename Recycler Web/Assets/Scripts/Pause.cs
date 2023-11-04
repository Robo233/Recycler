using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Background;
    public GameObject SettingsButton;
    public GameObject PauseButton;
    public GameObject PauseMenu;

    GameObject[] Garbages;

    public Image image;

    public bool isPlaying;

    public int TotalRecyled;

    void Start(){
      TotalRecyled = PlayerPrefs.GetInt("TotalRecycled");
    }

    public void Test(){
      OnApplicationFocus(false);
    }

    public void PauseFunction(){
        isPlaying = false;
        GetComponent<Speed>().enabled = false;
        Time.timeScale = 0;
        Background.SetActive(true);
        PauseButton.SetActive(false);
        SettingsButton.SetActive(true);
        PauseMenu.SetActive(true);
        Garbages = GameObject.FindGameObjectsWithTag("GarbageClone"); 
        for(int i=0;i<Garbages.Length;i++){
            
          image = Garbages[i].GetComponent<Image>();
          var tempColor = image.color;
          tempColor.a = 0.5f;
          image.color = tempColor;

          Garbages[i].GetComponent<Image>().raycastTarget = false;
        }
    
    }

    public void ResumeFunction(){
        isPlaying = true;
        GetComponent<Speed>().enabled = true;
        Time.timeScale = 1;
        Background.SetActive(false);
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        SettingsButton.SetActive(false);
    

        for(int i=0;i<Garbages.Length;i++){
            
          image = Garbages[i].GetComponent<Image>();
          var tempColor = image.color;
          tempColor.a = 1f;
          image.color = tempColor;

          Garbages[i].GetComponent<Image>().raycastTarget = true;
        }

    }

    public void MainMenu(){
             TotalRecyled += GetComponent<GameOver>().score;
             PlayerPrefs.SetInt("TotalRecycled",TotalRecyled);
             SceneManager.LoadScene( SceneManager.GetActiveScene().name );
             GetComponent<AdsManager>().PlayAd();
             
    }

     public void Quit(){
         Application.Quit();
    }

    private void OnApplicationPause(bool pause)
	{
		if (pause && isPlaying)
		{
			PauseFunction();
		}
	}

   private void OnApplicationFocus(bool pause)
	{
		if (!pause && isPlaying)
		{
			PauseFunction();
		}
	}

}
