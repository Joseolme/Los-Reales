using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

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
    public int dayNumber = 0;
    public Mesh[] nivelesDeMamado;
    public bool ciclado = false;

    private void Start()
    {
        dayNumber = 0;
    }
    public void ImplementResults(float value)
    {
        fitnessPuntctuation += value;
        Debug.Log("Current fitness punctuation = "+ fitnessPuntctuation);
    }
    public void LoadEvaluation()
    {
        SceneManager.LoadScene("Evaluation");
        dayNumber++;

        GameObject playerRepresentation = GameObject.FindGameObjectWithTag("PlayerRepresenatation");
        if (ciclado){
            playerRepresentation.GetComponentInChildren<MeshFilter>().mesh = nivelesDeMamado[3];
        }else if(fitnessPuntctuation > 70){
            playerRepresentation.GetComponentInChildren<MeshFilter>().mesh = nivelesDeMamado[2];
        }else if (fitnessPuntctuation > 40){
            playerRepresentation.GetComponentInChildren<MeshFilter>().mesh = nivelesDeMamado[1];
        }else{
            playerRepresentation.GetComponentInChildren<MeshFilter>().mesh = nivelesDeMamado[0];
        }
    }

    public void LoadNextDay()
    {
        SceneManager.LoadScene("Desayuno");
    }
}
