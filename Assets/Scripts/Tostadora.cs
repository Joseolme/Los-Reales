using UnityEngine;

public class Tostadora : MonoBehaviour
{
    private float maxTime = 5;
    private float currentTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > maxTime) { 
        
        }
    }
}
