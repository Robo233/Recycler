using UnityEngine;

public class GarbageMovement : MonoBehaviour
{
    public GameObject target;
    
    Vector3 b;

    float speedOfGarbage;

    public Speed speed;

    public GameOver gameOver;

    public AudioSource LoseHeartSound;



   
    void FixedUpdate()
    {
        speedOfGarbage = speed.garbageSpeed;

        Vector3 a = transform.position;
        Vector3 b = target.transform.position;
        transform.position = Vector2.MoveTowards(a, b, speedOfGarbage);
      
        if(transform.localPosition.y < target.transform.localPosition.y+50){
            
            if(gameOver.GameMode == "InfinitEasy"){
                gameOver.Hearts--;
                if(gameOver.Hearts!=0){
                LoseHeartSound.Play();
                }
                
            }
            else{
            gameOver.GameOverFunction();
            }
            Destroy(gameObject);
        }
        
    }
}
