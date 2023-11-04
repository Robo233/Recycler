using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameOver : MonoBehaviour
{
   public Text Counter;
   public Text HighScore;
   public Text HighScoreEasy;
   public Text HighScoreHard;
   public Text GameOverScore;
   public Text GameOverHighScore;
   public Text CompleteLevelTitle;
   public Text TotalRecycledText;

   public GameObject GameOverMenu;
   public GameObject Bins;
   public GameObject InGameUI;
   public GameObject NewHighScoreText;
   public GameObject LevelCompletedCanvas;
   public GameObject PreviousLevelButton;
   public GameObject NextLevelButton;
   public GameObject GameOverRestartButton;
   public GameObject GameOverRestartButtonEasy;
   public GameObject GameOverRestartButtonHard;
   public GameObject GameOverRestartButtonLevel;
   public GameObject GameOverScoreText;
   public GameObject GameOverHighscoreText;
   public GameObject GameOverLevel;
   public GameObject GameOverLevelScore;
   public GameObject Heart1;
   public GameObject Heart2;
   public GameObject Heart3;

   GameObject[] Garbages;
   public GameObject[] BinObjects;

   public AudioSource GameOverSound;

    public int score;
    public int FinishAfter;
    public int Hearts = 3;
    int bestEasy;
    int best;
    int bestHard;
    public int TotalRecyled;
    


    public string GameMode;

    public Levels levels;

    public Color EasyLevelOriginalColor;
    public Color MediumLevelOriginalColor;
    public Color HardLevelOriginalColor;

    public bool isLevelSet;

    public AudioSource LoseHeartSound;

    void Start(){
      bestEasy = PlayerPrefs.GetInt("BestEasy");
      best = PlayerPrefs.GetInt("Best");
      bestHard = PlayerPrefs.GetInt("BestHard");

      HighScore.text = HighScore.text + best.ToString();
      HighScoreEasy.text = HighScoreEasy.text + bestEasy.ToString();
      HighScoreHard.text = HighScoreHard.text + bestHard.ToString();

      TotalRecyled = PlayerPrefs.GetInt("TotalRecycled");
      TotalRecycledText.text = "Total  recycled:" + TotalRecyled.ToString();
  
    }

    void Update(){

      

      if(GameMode == "Level"){
         NewHighScoreText.SetActive(false);
        if(score == FinishAfter && !isLevelSet ){
            LevelCompletedFunction();
            
            isLevelSet = true;
            
        }
        }
        else{

          if(GameMode == "InfinitEasy"){
            if(Hearts==3){
              Heart1.SetActive(true);
              Heart2.SetActive(true);
              Heart3.SetActive(true);
            
              
            }else if(Hearts==2){
              Heart1.SetActive(false);
              Heart2.SetActive(true);
              Heart3.SetActive(true);
              
            }
            else if(Hearts==1){
              Heart1.SetActive(false);
              Heart2.SetActive(false);
              Heart3.SetActive(true);
              
            }else if(Hearts==0){
              GameOverFunction();
              Hearts = 3;
            }
          }

        }

    if(GameMode == "Infinit"){
        if(score > best){
        
        NewHighScoreText.SetActive(true);
        best = score;
        PlayerPrefs.SetInt("Best", best);
        HighScore.text = HighScore.text + (best+1).ToString();
      }
      else if(score < best){
        NewHighScoreText.SetActive(false);
      }
    }
    else if(GameMode == "InfinitEasy"){
        if(score > bestEasy){
        
        NewHighScoreText.SetActive(true);
        bestEasy = score;
        PlayerPrefs.SetInt("BestEasy", bestEasy);
        HighScore.text = HighScore.text + (bestEasy+1).ToString();
      }
      else if(score < bestEasy){
        NewHighScoreText.SetActive(false);
      }
    }
      else if(GameMode == "InfinitHard"){
        if(score > bestHard){
        
        NewHighScoreText.SetActive(true);
        bestHard = score;
        PlayerPrefs.SetInt("BestHard", bestHard);
        HighScore.text = HighScore.text + (bestHard+1).ToString();
      }
      else if(score < bestHard){
        NewHighScoreText.SetActive(false);
      }
    }
     
      Counter.text = score.ToString();
      if(score>=10 && score<100 ){
        Counter.gameObject.transform.localPosition = new Vector3(272.15f, Counter.gameObject.transform.localPosition.y, Counter.gameObject.transform.localPosition.z);
      }

     else if(score>=100 ){
        Counter.gameObject.transform.localPosition = new Vector3(230.3f, Counter.gameObject.transform.localPosition.y, Counter.gameObject.transform.localPosition.z);
      }
      else{
        Counter.gameObject.transform.localPosition = new Vector3(280f, Counter.gameObject.transform.localPosition.y, Counter.gameObject.transform.localPosition.z);
      }

    }

    public void LevelCompletedFunction(){
        GetComponent<Pause>().isPlaying = false;
        if(GetComponent<StartGame>().CurrentLevel == levels.LevelNumberEasy && GetComponent<StartGame>().CurrentLevel<36 && levels.LevelNumberEasy<12 ){
        levels.LevelNumberEasy++;
        PlayerPrefs.SetInt("LevelNumberEasy", levels.LevelNumberEasy);
        }

        if(GetComponent<StartGame>().CurrentLevel == levels.LevelNumberMedium+12 && GetComponent<StartGame>().CurrentLevel<36 && levels.LevelNumberMedium<12 ){
        levels.LevelNumberMedium++;
        PlayerPrefs.SetInt("LevelNumberMedium", levels.LevelNumberMedium);
        }

        if(GetComponent<StartGame>().CurrentLevel == levels.LevelNumberHard+24 && GetComponent<StartGame>().CurrentLevel<36 && levels.LevelNumberHard<12 ){
        levels.LevelNumberHard++;
        PlayerPrefs.SetInt("LevelNumberHard", levels.LevelNumberHard);
        }
        

        LevelCompletedCanvas.SetActive(true);
        CompleteLevelTitle.text = "Level " + GetComponent<StartGame>().CurrentLevel.ToString();

        if(GetComponent<StartGame>().CurrentLevel > 1){
          Debug.Log("Bigger than one");          
          PreviousLevelButton.SetActive(true);
          if(GetComponent<StartGame>().CurrentLevel == 13 && GetComponent<Levels>().LevelNumberEasy!=12){
            PreviousLevelButton.SetActive(false);
          }
          if(GetComponent<StartGame>().CurrentLevel == 25 && GetComponent<Levels>().LevelNumberMedium!=12){
            PreviousLevelButton.SetActive(false);
          }
        }

          if(GetComponent<StartGame>().CurrentLevel < 36){
          NextLevelButton.SetActive(true);
        }

        Garbages = GameObject.FindGameObjectsWithTag("GarbageClone");
        for(int i=0;i<Garbages.Length;i++){
           Destroy(Garbages[i]);
        }

          for(int i=0;i<BinObjects.Length;i++){
           BinObjects[i].GetComponentInChildren<Image>().enabled = false;
       }

        Time.timeScale = 0;
        GetComponent<Speed>().enabled = false;

        GetComponent<StartGame>().CurrentBinTypes.Clear();
        GetComponent<GarbageGenerator>().Garbages.Clear();
        Array.Clear(GetComponent<StartGame>().BinPositions, 0, GetComponent<StartGame>().BinPositions.Length);
        GetComponent<GarbageGenerator>().CurrentGarbages.Clear();
        GetComponent<StartGame>().CurrentBinTypes.Clear();

        TotalRecyled += score;
        PlayerPrefs.SetInt("TotalRecycled",TotalRecyled);

    }

    public void GameOverFunction(){
        GetComponent<Pause>().isPlaying = false;

        if(GameMode=="Infinit"){
           if(score > best){
             best = score;
        PlayerPrefs.SetInt("Best", best);
        NewHighScoreText.SetActive(true);
        
      }
      else if(score < best){
        NewHighScoreText.SetActive(false);
      }
      GameOverHighScore.text = "Highscore : " + best.ToString();
        }
        else if(GameMode=="InfinitEasy"){

           if(score > bestEasy){
             bestEasy = score;
        PlayerPrefs.SetInt("Best", bestEasy);
        NewHighScoreText.SetActive(true);
        
      }
      else if(score < bestEasy){
        NewHighScoreText.SetActive(false);
      
        }
        GameOverHighScore.text = "Highscore : " + bestEasy.ToString();
        }
          else if(GameMode=="InfinitHard"){

           if(score > bestHard){
             bestHard = score;
        PlayerPrefs.SetInt("Best", bestHard);
        NewHighScoreText.SetActive(true);
        
      }
      else if(score < bestHard){
        NewHighScoreText.SetActive(false);
      
        }
        GameOverHighScore.text = "Highscore : " + bestHard.ToString();
        }


        GameOverSound.Play();
        GameOverMenu.SetActive(true);
        Bins.SetActive(false);
        InGameUI.SetActive(false);
        Garbages = GameObject.FindGameObjectsWithTag("GarbageClone");
        for(int i=0;i<Garbages.Length;i++){
           Destroy(Garbages[i]);
        }
        Time.timeScale = 0;
        GetComponent<Speed>().enabled = false;
        GameOverScore.text = "Score : " + score.ToString();
      

      if(GameMode=="Level"){
        GameOverRestartButtonLevel.SetActive(true);
        GameOverLevel.SetActive(true);
        GameOverLevelScore.SetActive(true);
        GameOverLevelScore.GetComponent<Text>().text = "Score : " + score.ToString() + "/" + GetComponent<StartGame>().CurrentFinishAfter.ToString();
        GameOverLevel.GetComponent<Text>().text = "Level " + GetComponent<StartGame>().CurrentLevel;
        GameOverScoreText.SetActive(false);
        GameOverHighscoreText.SetActive(false);
        
      }
      else if(GameMode=="Infinit"){
          GameOverRestartButton.SetActive(true);
      }else if(GameMode=="InfinitEasy"){
        GameOverRestartButtonEasy.SetActive(true);
      }
      else if(GameMode=="InfinitHard"){
        GameOverRestartButtonHard.SetActive(true);
      }

      GetComponent<StartGame>().CurrentBinTypes.Clear();
        GetComponent<GarbageGenerator>().Garbages.Clear();
        Array.Clear(GetComponent<StartGame>().BinPositions, 0, GetComponent<StartGame>().BinPositions.Length);

        TotalRecyled += score;
        PlayerPrefs.SetInt("TotalRecycled",TotalRecyled);
        
    }

    public void Revive(){
      GetComponent<Pause>().isPlaying = true;
     GameOverMenu.SetActive(false);
     Bins.SetActive(true);
     InGameUI.SetActive(true);
     Time.timeScale = 1;
     GetComponent<Speed>().enabled = true;

    }

}
