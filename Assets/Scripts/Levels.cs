using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Levels : MonoBehaviour
{
    public GameObject[] Bins;
    public GameObject[] LevelLockedObjectsEasy;
    public GameObject[] LevelCompletedObjectsEasy;
    public GameObject[] LevelLockedObjectsMedium;
    public GameObject[] LevelCompletedObjectsMedium;
    public GameObject[] LevelLockedObjectsHard;
    public GameObject[] LevelCompletedObjectsHard;

    public int currentLevel;
    public int LevelNumberEasy;
    public int LevelNumberMedium;
    public int LevelNumberHard;

    public float left;
    public float right;

    public Image image;

    public Color UnCompletedLevelColor;

    void Start(){

        if(PlayerPrefs.GetInt("LevelNumberEasy") == 0){
            PlayerPrefs.SetInt("LevelNumberEasy",1);
        }

         if(PlayerPrefs.GetInt("LevelNumberMedium") == 0){
            PlayerPrefs.SetInt("LevelNumberMedium",1);
        }

         if(PlayerPrefs.GetInt("LevelNumberHard") == 0){
            PlayerPrefs.SetInt("LevelNumberHard",1);
        }

        LevelNumberEasy = PlayerPrefs.GetInt("LevelNumberEasy");
        LevelNumberMedium = PlayerPrefs.GetInt("LevelNumberMedium");
        LevelNumberHard = PlayerPrefs.GetInt("LevelNumberHard");

    }


    void Update(){

        for(int i=0;i<LevelNumberEasy;i++){
            LevelLockedObjectsEasy[i].SetActive(false);
            LevelCompletedObjectsEasy[i].SetActive(true);
        }

        for(int i=0;i<LevelNumberMedium;i++){
            LevelLockedObjectsMedium[i].SetActive(false);
            LevelCompletedObjectsMedium[i].SetActive(true);
        }

        for(int i=0;i<LevelNumberHard;i++){
            LevelLockedObjectsHard[i].SetActive(false);
            LevelCompletedObjectsHard[i].SetActive(true);
        }

    }

    public void ChooseLevel(){
        
        string CurrentLevelButtonName = EventSystem.current.currentSelectedGameObject.name;
        currentLevel = Int32.Parse(BeforeLastWord(CurrentLevelButtonName));
        SelectLevel(currentLevel);
    }

    public void SelectLevel(int currentLevel){
        
        switch(currentLevel) 
        {
            case 1:
            GetComponent<StartGame>().StartGameFunction( 1, "Level", new List<string>(new string[] { "Metal" } ), new Vector2[] {new Vector2(left,0)}, 3.5f, 2f, 0, 0, 5 ); 
            break;

            case 2:
            GetComponent<StartGame>().StartGameFunction( 2, "Level", new List<string>(new string[] { "Organic", "Plastic" } ), new Vector2[] {new Vector2(left,0), new Vector2(left,-300)}, 3.6f, 2f, 0, 0, 6 ); 
            break;

            case 3:
            GetComponent<StartGame>().StartGameFunction( 3, "Level", new List<string>(new string[] { "Paper", "E-Waste" } ), new Vector2[] {new Vector2(left,-34), new Vector2(right,-340)}, 3.7f, 2f, 0, 0, 7 ); 
            break;

            case 4:    
            GetComponent<StartGame>().StartGameFunction( 4, "Level", new List<string>(new string[] { "Metal", "Glass" } ), new Vector2[] {new Vector2(left,-122), new Vector2(right,276)}, 3.8f, 2f, 0, 0, 8 );
            break;

            case 5:
            GetComponent<StartGame>().StartGameFunction( 5, "Level", new List<string>(new string[] { "Metal", "E-Waste", "Paper" } ), new Vector2[] {new Vector2(left,0), new Vector2(left,263.98f), new Vector2(left,-319.8f) }, 3.9f, 2f, 0, 0, 9 ); 
            break;

            case 6:
            GetComponent<StartGame>().StartGameFunction( 6, "Level", new List<string>(new string[] { "Metal", "Plastic", "Organic" } ), new Vector2[] {new Vector2(left,322), new Vector2(left,-156), new Vector2(right,123)}, 4f, 2f, 0, 0, 10 ); 
            break;

            case 7:
            GetComponent<StartGame>().StartGameFunction( 7, "Level", new List<string>(new string[] { "Plastic", "E-Waste", "Organic" } ), new Vector2[] {new Vector2(left,343), new Vector2(right,-77), new Vector2(right,233)}, 4.1f, 2f, 0, 0, 11 ); 
            break;

            case 8:
            GetComponent<StartGame>().StartGameFunction( 8, "Level", new List<string>(new string[] { "Plastic", "Paper", "Glass" } ), new Vector2[] {new Vector2(right,322), new Vector2(right,-276), new Vector2(right,12)}, 4.2f, 2f, 0, 0, 12 ); 
            break;

            case 9:
            GetComponent<StartGame>().StartGameFunction( 9, "Level", new List<string>(new string[] { "Paper", "Organic", "Glass" } ), new Vector2[] {new Vector2(left,39), new Vector2(right,-321), new Vector2(right,5)}, 4.3f, 2f, 0, 0, 13 ); 
            break;

            case 10:
            GetComponent<StartGame>().StartGameFunction( 10, "Level", new List<string>(new string[] { "Metal", "Organic", "E-Waste" } ), new Vector2[] {new Vector2(left,321), new Vector2(left,24.5f), new Vector2(left,-239)}, 4.4f, 2f, 0, 0, 14 );  
            break;

            case 11:
            GetComponent<StartGame>().StartGameFunction( 11, "Level", new List<string>(new string[] { "Metal", "Glass", "E-Waste" } ), new Vector2[] {new Vector2(left,303), new Vector2(left,-134), new Vector2(right,123)}, 4.5f, 2f, 0, 0, 15 ); 
            break;

            case 12:
            GetComponent<StartGame>().StartGameFunction( 12, "Level", new List<string>(new string[] { "Glass", "Plastic", "Paper" } ), new Vector2[] {new Vector2(left,222), new Vector2(right,-287), new Vector2(right,7)}, 4.6f, 2f, 0, 0, 16 );                   
            break;

            case 13:
            GetComponent<StartGame>().StartGameFunction( 13, "Level", new List<string>(new string[] { "E-Waste", "Plastic", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,331), new Vector2(left,-298), new Vector2(left,5), new Vector2(right,23) }, 4.7f, 2f, 0, 0, 17 );   
            break;

            case 14:
            GetComponent<StartGame>().StartGameFunction( 14, "Level", new List<string>(new string[] { "Metal", "Plastic", "Paper", "Glass" } ), new Vector2[] {new Vector2(left,45.6f), new Vector2(right,-334), new Vector2(right,-41), new Vector2(right,249)}, 4.8f, 2f, 0, 0, 18 );   
            break;

            case 15:
            GetComponent<StartGame>().StartGameFunction( 15, "Level", new List<string>(new string[] { "Plastic", "Metal", "Organic", "Glass" } ), new Vector2[] {new Vector2(left,328), new Vector2(left,-134), new Vector2(right,23), new Vector2(right,323)}, 4.9f, 2f, 0,0, 19 );   
            break;

            case 16:
            GetComponent<StartGame>().StartGameFunction( 16, "Level", new List<string>(new string[] { "Plastic", "Paper", "Organic", "E-Waste" } ), new Vector2[] {new Vector2(left,337), new Vector2(left,-328), new Vector2(left,13), new Vector2(right,223)}, 5f, 2f, 0, 0, 20 ); 
            break;

            case 17:
            GetComponent<StartGame>().StartGameFunction( 17, "Level", new List<string>(new string[] { "Metal", "Paper", "E-Waste", "Glass" } ), new Vector2[] {new Vector2(left,78), new Vector2(right,-299), new Vector2(right,323), new Vector2(right,-26)}, 5.1f, 2f, 0, 0, 21 ); 
            break;

            case 18:
            GetComponent<StartGame>().StartGameFunction( 18, "Level", new List<string>(new string[] { "E-Waste", "Organic", "Glass", "Metal" } ), new Vector2[] {new Vector2(left,341), new Vector2(left,9), new Vector2(right,238), new Vector2(right,-121)}, 5.2f, 2f, 0, 0, 22 );     
            break;

            case 19:
            GetComponent<StartGame>().StartGameFunction( 19, "Level", new List<string>(new string[] { "Metal", "Plastic", "Paper", "Organic", "Glass" } ), new Vector2[] {new Vector2(left,336), new Vector2(left,-301), new Vector2(left,4), new Vector2(right,321), new Vector2(right,-43) }, 5.3f, 2f, 0, 0, 23 );  
            break;

            case 20:
            GetComponent<StartGame>().StartGameFunction( 20, "Level", new List<string>(new string[] { "Metal", "Plastic", "Paper", "Organic", "E-Waste" } ), new Vector2[] {new Vector2(left,341), new Vector2(left,-199), new Vector2(right,348), new Vector2(right,2), new Vector2(right,-312)}, 5.4f, 2f, 0, 0, 24 ); 
            break;

            case 21:
            GetComponent<StartGame>().StartGameFunction( 21, "Level", new List<string>(new string[] { "Metal", "Plastic", "Paper", "Glass", "E-Waste" } ), new Vector2[] {new Vector2(left,333), new Vector2(left,58), new Vector2(left,-323), new Vector2(right,211), new Vector2(right,-239)}, 5.5f, 2f, 0, 0, 25 ); 
            break;

            case 22:
            GetComponent<StartGame>().StartGameFunction( 22, "Level", new List<string>(new string[] { "Metal", "Plastic", "Organic", "Glass", "E-Waste" } ), new Vector2[] {new Vector2(left,336), new Vector2(left,-234), new Vector2(right,211), new Vector2(right,-50), new Vector2(right,-348)}, 5.6f, 2f, 0, 0, 26 ); 
            break;

            case 23:
            GetComponent<StartGame>().StartGameFunction( 23, "Level", new List<string>(new string[] { "Metal", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] {new Vector2(left,342), new Vector2(left,21), new Vector2(left,-312), new Vector2(right,302), new Vector2(right,-213)}, 5.7f, 2f, 0, 0, 27 ); 
            break;

            case 24:
            GetComponent<StartGame>().StartGameFunction( 24, "Level", new List<string>(new string[] { "Plastic", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] {new Vector2(left,252), new Vector2(left,-54), new Vector2(right,337), new Vector2(right,27), new Vector2(right,-323)}, 5.8f, 2f, 0, 0, 28 ); 
            break;

             case 25:
            GetComponent<StartGame>().StartGameFunction( 25, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,341), new Vector2(left,0), new Vector2(left,-322), new Vector2(right,332), new Vector2(right,23),new Vector2(right,-312)}, 5.3f, 1.5f, 0, 0, 29 );  
            break;

            case 26:
            GetComponent<StartGame>().StartGameFunction( 26, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,339), new Vector2(left,3), new Vector2(left,-333), new Vector2(right,339), new Vector2(right,12), new Vector2(right,-344)}, 5.4f, 1.5f, 0, 0, 30 );  
            break;

            case 27:
            GetComponent<StartGame>().StartGameFunction( 27, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,337), new Vector2(left,15), new Vector2(left,-344), new Vector2(right,342), new Vector2(right,-11), new Vector2(right,-348)}, 5.5f, 1.5f, 0, 0, 31 ); 
            break;

            case 28:
            GetComponent<StartGame>().StartGameFunction( 28, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,335), new Vector2(left,21), new Vector2(left,-347), new Vector2(right,347), new Vector2(right,2), new Vector2(right,-347)}, 5.6f, 1.5f, 0, 0, 32 );  
            break;

            case 29:
            GetComponent<StartGame>().StartGameFunction( 29, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,334), new Vector2(left,25), new Vector2(left,-349), new Vector2(right,340), new Vector2(right,0), new Vector2(right,-332)}, 5.7f, 1.5f, 0, 0, 33 );  
            break;

            case 30:
            GetComponent<StartGame>().StartGameFunction( 30, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,347), new Vector2(left,-1), new Vector2(left,-339), new Vector2(right,336), new Vector2(right,-21), new Vector2(right,-339)}, 5.8f, 1.5f, 0, 0, 34 );  
            break;

            case 31:
            GetComponent<StartGame>().StartGameFunction( 31, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,342), new Vector2(left,-7), new Vector2(left,-330), new Vector2(right,378), new Vector2(right,0), new Vector2(right,-340)}, 5.9f, 1.5f, 0, 0, 35 ); 
            break;

            case 32:
            GetComponent<StartGame>().StartGameFunction( 32, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,343), new Vector2(left,17), new Vector2(left,-327), new Vector2(right,365), new Vector2(right,27), new Vector2(right,-342)}, 6f, 1.5f, 0, 0, 36 ); 
            break;

            case 33:
            GetComponent<StartGame>().StartGameFunction( 33, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,350), new Vector2(left,7), new Vector2(left,-323), new Vector2(right,391), new Vector2(right,29), new Vector2(right,-332)}, 6.1f, 1.5f, 0, 0, 37 ); 
            break;

            case 34:
            GetComponent<StartGame>().StartGameFunction( 34, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,349), new Vector2(left,18), new Vector2(left,-329), new Vector2(right,329), new Vector2(right,-13), new Vector2(right,-340)}, 6.2f, 1.5f, 0, 0, 38 ); 
            break;

            case 35:
            GetComponent<StartGame>().StartGameFunction( 35, "Level", new List<string>(new string[] { "Metal", "Plastic", "Glass", "E-Waste", "Paper", "Organic" } ), new Vector2[] {new Vector2(left,329), new Vector2(left,-19), new Vector2(left,-345), new Vector2(right,341), new Vector2(right,9), new Vector2(right,-342)}, 6.3f, 1.5f, 0, 0, 39 ); 
            break;

            case 36:
            GetComponent<StartGame>().StartGameFunction( 36, "Level", new List<string>(new string[] { "Metal", "Plastic", "Paper", "Organic", "Glass", "E-Waste" } ), new Vector2[] {new Vector2(right,404.7f), new Vector2(left,51.21f), new Vector2(right,-262.5f), new Vector2(left,325), new Vector2(right,50), new Vector2(left,-292.9f) }, 6.4f, 1.5f, 0, 0, 40 ); 
            break;
           
        }

    }

    string BeforeLastWord(string str){
      string[] words = str.Split(new[] { " " }, StringSplitOptions.None);
	    return words[words.Length-2];
    }

    public void RestartLevel(){
        SelectLevel(currentLevel);
    }

   public void NextLevel(){
       
     
       GetComponent<GameOver>().isLevelSet = false;
       if(currentLevel<36){
           currentLevel++;
       }
       SelectLevel(currentLevel);
    }

     public void PreviousLevel(){
         GetComponent<GameOver>().isLevelSet = false;
         if(currentLevel>1){
           currentLevel--;
       }
       SelectLevel(currentLevel);
    }

}
