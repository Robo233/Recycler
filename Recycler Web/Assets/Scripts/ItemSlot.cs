using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameOver gameOver;
    
    public StartGame startGame;

    public AudioSource TrashSound;
    public AudioSource LevelCompleteSound;


    public void OnDrop(PointerEventData eventData){
      
        if(eventData.pointerDrag){
          if(FirstWord(eventData.pointerDrag.name) ==  FirstWord(gameObject.name) ){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Destroy(eventData.pointerDrag);
            gameOver.score++; 
              if(gameOver.score == startGame.CurrentFinishAfter){
              LevelCompleteSound.Play();
              }
              else{
                TrashSound.Play();
              }
          
        }
        else if(gameOver.GameMode=="InfinitHard"){
          gameOver.GameOverFunction();
        }
        }

          if(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition.x > 250){
             
        }

    }

    string FirstWord(string str){
      string[] words = str.Split(new[] { " " }, StringSplitOptions.None);
	    return words[0];
    }
}
