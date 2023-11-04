using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GarbageGenerator : MonoBehaviour
{
   public GameObject Canvas;
   public GameObject SpawnPoint;
   
   public List<GameObject> Garbages = new List<GameObject>();
   public List<string> CurrentGarbages = new List<string>();

   float timer = 0.1f;
   float timeUntilNextGarbageIsSpawned = 6;

   void Update(){

       timeUntilNextGarbageIsSpawned = gameObject.GetComponent<Speed>().timeUntilNextGarbageIsSpawned;

        timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeUntilNextGarbageIsSpawned;
                StartCoroutine(GarbageGeneratorFunction());
            }

      
            
   }

   GameObject RandomGarbage(){
     
     for(int i=0;i<CurrentGarbages.Count;i++){
      Garbages.AddRange(GameObject.FindGameObjectsWithTag(FirstWord(CurrentGarbages[i])).ToList());
     }
      GameObject chosenGameObject;
      chosenGameObject = Garbages[UnityEngine.Random.Range(0,Garbages.Count)];
    
      return chosenGameObject;
   


   }

   IEnumerator GarbageGeneratorFunction(){

    yield return new WaitForSeconds(0);
    GameObject newGarabge = GameObject.Instantiate(RandomGarbage());
    newGarabge.tag = "GarbageClone";
    newGarabge.GetComponent<GarbageMovement>().enabled = true;
    newGarabge.transform.SetParent(Canvas.transform);
    newGarabge.transform.localPosition = SpawnPoint.transform.localPosition; 
   }

   string FirstWord(string str){
       string[] words = str.Split(new[] { " " }, StringSplitOptions.None);
	    return words[0];
   }



}
