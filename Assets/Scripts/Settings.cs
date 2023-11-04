using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject SettingsObject;
    public GameObject SoundButton;
    public GameObject CreditsMenu;
    public GameObject CreditsButton;
    public GameObject TutorialButton;
    public GameObject HighScoreTextEasy;
    public GameObject HighScoreTextMedium;
    public GameObject HighScoreTextHard;
    public GameObject TotalRecycled;


    public Sprite MuteButton;
    public Sprite UnMuteButton;

    void Start() {
        if(PlayerPrefs.GetInt("isMuted")==1){
            AudioListener.volume = 0;
            SoundButton.GetComponent<Image>().sprite = UnMuteButton;
        }
        else{
            AudioListener.volume = 1;
            SoundButton.GetComponent<Image>().sprite = MuteButton;
        }
    }

public void SettingsMenuOn(){
  SettingsObject.SetActive(true);

}

public void SettingsMenuOff(){
    
    if(CreditsMenu.activeSelf){
    CreditsMenu.SetActive(false);
    CreditsButton.SetActive(true);
    SoundButton.SetActive(true);
    TutorialButton.SetActive(true);
    TotalRecycled.SetActive(true);
    HighScoreTextEasy.SetActive(true);
    HighScoreTextMedium.SetActive(true);
    HighScoreTextHard.SetActive(true);
    }
    else{
    SettingsObject.SetActive(false);
    
    }
    
}

public void Sound(){
    if(AudioListener.volume == 0){
        AudioListener.volume = 1;
        SoundButton.GetComponent<Image>().sprite = MuteButton;
        PlayerPrefs.SetInt("isMuted", 0);
    }
    else{
        AudioListener.volume = 0;
        SoundButton.GetComponent<Image>().sprite = UnMuteButton;
        PlayerPrefs.SetInt("isMuted", 1);
    }
}


}
