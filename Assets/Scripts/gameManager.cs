using Unity.VisualScripting;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton pattern
    /// </summary>
    public static gameManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    [Range(0f, 100f)]
    public float fitnessPuntctuation = 50;

    public void ImplementResults(float value)
    {
        fitnessPuntctuation += value;
        Debug.Log("Current fitness punctuation = "+ fitnessPuntctuation);
    }
}
