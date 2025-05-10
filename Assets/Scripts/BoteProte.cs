using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BoteProte : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private Transform transform;
    public float maxTime;

    //time values
    private float currentTime;
    //rotation values
    public float rotationSpeed;
    private int currentRotation;
    private Vector3 frameRotation;
    [SerializeField] int maxRotation = 100;
    //amount of protein values
    private float currentProte;
    private float obectiveProte;
    [SerializeField] private float proteAdd = 10f;
    public float maxProteVariation = .15f;
    
    //RepresentationValues
    [SerializeField] GameObject proteinObject;
    [SerializeField] GameObject proteMarker;
    
    //FitnessPunctuation values
    public int maxFitnessPunctuation = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform = rb.GetComponent<Transform>();
        frameRotation = new Vector3(0, 0, 0);
        rotationSpeed = rotationSpeed / 10;
        proteAdd = proteAdd / 100;
    }
    void Start()
    {
        currentTime = 0;
        obectiveProte = Random.Range(.15f, .6f);
        currentProte = 0;

        PlaceReference();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;


        //Choose direction to turn
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frameRotation = new Vector3(0, 0, rotationSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            frameRotation = new Vector3(0, 0, -rotationSpeed);
        }


        transform.Rotate(frameRotation);
        if (transform.rotation.eulerAngles.z > 200)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        currentProte += (proteAdd / 10 * transform.rotation.eulerAngles.z / 100);
        GrowProtein();


        //si la cagas te resta 10al fittness
        if (transform.rotation.eulerAngles.z >= maxRotation)
        {
            gameManager.Instance.ImplementResults(-10);
            Destroy(this);
        }
        //Si haces el tiempo te da puntuación basada en tu desviamiento
        if (currentTime >= maxTime)
        {

            Debug.Log(calculatePrecision());
            float fitnessPunctuation = maxFitnessPunctuation * calculatePrecision() ;
            gameManager.Instance.ImplementResults(fitnessPunctuation);
            Destroy(this);
        }
    }

    private void PlaceReference()
    {
        proteMarker.GetComponent<Renderer>().material.SetFloat("_Z_Pos", obectiveProte);
    }
    private void GrowProtein()
    {
        Debug.Log(currentProte);
        proteinObject.transform.localScale = new Vector3(proteinObject.transform.localScale.x, currentProte *2, proteinObject.transform.localScale.z);
    }
    private float calculatePrecision()
    {
        Debug.Log("current prote " + currentProte + " Objective prote " + obectiveProte);
        if (currentProte >= obectiveProte - (maxProteVariation *.2f) && currentProte <= obectiveProte + (maxProteVariation * .2f))
        {
            return 1;

        }
        else if (currentProte >= obectiveProte - (maxProteVariation * .5f) && currentProte <= obectiveProte + (maxProteVariation * .5f))
        {
            return .5f;

        }
        else if (currentProte >= obectiveProte - maxProteVariation && currentProte <= obectiveProte + maxProteVariation)
        {
            return .25f;

        }
        else return 0;
    }
}
