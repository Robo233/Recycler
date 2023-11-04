using UnityEngine;

public class Speed : MonoBehaviour
{
   public float garbageSpeed;
   public float timeUntilNextGarbageIsSpawned;
   public float garbageAcceleration;
   public float garbageGeneratorAcceleration;

    void Update() {
        garbageSpeed += garbageAcceleration;
        timeUntilNextGarbageIsSpawned += garbageGeneratorAcceleration;
    }

}
