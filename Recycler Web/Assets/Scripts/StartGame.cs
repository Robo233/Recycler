using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartGame : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject PauseButton;
    public GameObject SettingsButton;
    public GameObject BackgroundImage;
    public GameObject QuitButton;
    public GameObject Counter;
    public GameObject HighScore;
    public GameObject GameOverMenu;
    public GameObject Bins;
    public GameObject InGameUI;
    public GameObject MainMenu;
    public GameObject LevelCanvas;
    public GameObject LevelCompletedCanvas;
    public GameObject PrivacyPolicy;
    public GameObject TutorialEasy;
    public GameObject TutorialMedium;
    public GameObject TutorialHard;

    public GameObject[] Garbages;

    public List<GameObject> BinTypes = new List<GameObject>();
    public List<GameObject> CurrentBinTypes;

    public Vector2[] BinPositions;

    public bool isPlaying;

    public GameOver gameOver;

    public int CurrentLevel;
    public int CurrentFinishAfter;
    
    float left;
    float right;

    bool isPrivacyPolicyAgreed;

    public string CurrentGameMode;

    Quaternion BinRotationLeft = Quaternion.Euler(0, 0, -10);
    Quaternion BinRotationRight = Quaternion.Euler(0, 0, 10);

    public Levels levels;

    void Start(){

        left = GetComponent<Levels>().left;
        right = GetComponent<Levels>().right;
        
        isPrivacyPolicyAgreed = Convert.ToBoolean(PlayerPrefs.GetInt("isPrivacyPolicyAgreed"));

        if(isPrivacyPolicyAgreed){
          //  PrivacyPolicy.SetActive(false);
        }
        else{
          //  PrivacyPolicy.SetActive(true);
        }



    }

     public void StartGameInfinitEasy(){
        
        Debug.Log("asd");
    
        if(PlayerPrefs.GetInt("isFirstTimePlayingInfinitEasy") == 0){
            TutorialEasy.SetActive(true);
            PlayerPrefs.SetInt("isFirstTimePlayingInfinitEasy",1);
        }
        else{
             StartGameFunction(0, "InfinitEasy", new List<string> (new string[] { "Metal", "Plastic", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] { new Vector2(left,140), new Vector2(left,0), new Vector2(left,-140), new Vector2(right,140), new Vector2(right,0), new Vector2(right,-140) } , 3, 2, 0.0009f, -0.0002f, 0 );
            TutorialEasy.SetActive(false);
        }
    
    }

   public void StartGameInfinitReserve(){
       Debug.Log("asdasd");
       StartGameFunction(0, "Infinit", new List<string> (new string[] { "Metal", "Plastic", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] { new Vector2(left,140), new Vector2(left,0), new Vector2(left,-140), new Vector2(right,140), new Vector2(right,0), new Vector2(right,-140) } , 3, 2, 0.0009f, -0.0002f, 0 );
    }

    public void StartGameInfinitMedium(){
       
    
          if(PlayerPrefs.GetInt("isFirstTimePlayingInfinitMedium") == 0){
            TutorialMedium.SetActive(true);
            PlayerPrefs.SetInt("isFirstTimePlayingInfinitMedium",1);
        }
        else{
             StartGameFunction(0, "Infinit", new List<string> (new string[] { "Metal", "Plastic", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] { new Vector2(left,140), new Vector2(left,0), new Vector2(left,-140), new Vector2(right,140), new Vector2(right,0), new Vector2(right,-140) } , 3, 2, 0.0009f, -0.0002f, 0 );
            TutorialMedium.SetActive(false);
        }
    }

    

      public void StartGameInfinitHard(){
        

           if(PlayerPrefs.GetInt("isFirstTimePlayingInfinitHard") == 0){
            TutorialHard.SetActive(true);
            PlayerPrefs.SetInt("isFirstTimePlayingInfinitHard",1);
        }else{
            StartGameFunction(0, "InfinitHard", new List<string> (new string[] { "Metal", "Plastic", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] { new Vector2(left,140), new Vector2(left,0), new Vector2(left,-140), new Vector2(230,140), new Vector2(230,0), new Vector2(230,-140) } , 3, 2, 0.0006f, -0.0003f, 0 );
            TutorialHard.SetActive(false);
        }
    
    }


    public void StartGameFunction(int Level, string GameMode, List<string> BinTypeNames, Vector2[] BinPositionsLocal , float garbageSpeed, float timeUntilNextGarbageIsSpawned, float garbageAcceleration, float garbageGeneratorAcceleration, int FinishAfter){

        GetComponent<GameOver>().isLevelSet = false;
        GetComponent<Pause>().isPlaying = true;
        Bins.SetActive(true);
        CurrentLevel = Level;
        CurrentFinishAfter = FinishAfter;
        CurrentGameMode = GameMode;
        GetComponent<GarbageGenerator>().CurrentGarbages = BinTypeNames;
        GameOverMenu.SetActive(false);
        InGameUI.SetActive(true);
        Time.timeScale = 1;
        gameOver.score = 0;
        MainMenu.SetActive(false);
        GetComponent<Speed>().enabled = true;
        BackgroundImage.SetActive(false);
        isPlaying = true;
        HighScore.SetActive(false);
        BinPositions = BinPositionsLocal;

        Garbages = GameObject.FindGameObjectsWithTag("Garbage");
        for(int i=0;i<Garbages.Length;i++){
            Garbages[i].SetActive(true);
        }

         GetComponent<GarbageGenerator>().enabled = true;

       if(GameMode == "Level"){
           LevelCanvas.SetActive(false);
           LevelCompletedCanvas.SetActive(false);
       }

       for(int i=0;i<BinPositions.Length;i++){
           BinPositions[i] = new Vector2(BinPositions[i].x+50,BinPositions[i].y);
           
       }

        for(int i=0;i<BinTypeNames.Count;i++){
            CurrentBinTypes.Add(GameObject.Find(BinTypeNames[i]));
        }

        for(int i=0;i<CurrentBinTypes.Count;i++){
            if(CurrentBinTypes[i]){
            CurrentBinTypes[i].SetActive(true);
            CurrentBinTypes[i].GetComponentInChildren<Image>().enabled = true;
            CurrentBinTypes[i].transform.localPosition = BinPositions[i]; 
            if(BinPositions[i].x-50==levels.left){
                CurrentBinTypes[i].transform.localRotation = BinRotationLeft;
            }else{
                CurrentBinTypes[i].transform.localRotation = BinRotationRight;
            }

            }
           
        }

        GetComponent<GameOver>().FinishAfter = FinishAfter;
        GetComponent<GameOver>().GameMode = GameMode;

        GetComponent<Speed>().garbageSpeed = garbageSpeed;
        GetComponent<Speed>().timeUntilNextGarbageIsSpawned = timeUntilNextGarbageIsSpawned;
        GetComponent<Speed>().garbageAcceleration = garbageAcceleration;
        GetComponent<Speed>().garbageGeneratorAcceleration = garbageGeneratorAcceleration;
      
    }

public void AgreePrivacyPolicy(){
    PrivacyPolicy.SetActive(false);
    PlayerPrefs.SetInt("isPrivacyPolicyAgreed",1);
}

}
