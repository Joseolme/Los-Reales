using UnityEngine;

public class Sentadilla : MonoBehaviour
{
    public float pressure=35;
    public float pressureIncrease = 40;
    private int maxPressure = 100;
    public int pushStrength = 10;

    public float maxPunctuation = 10;

    private float maxTime = 5;
    private float currentTime = 0;

    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime+= Time.deltaTime;

        pressure += pressureIncrease/100;
        
        anim.SetFloat("Pressure", Mathf.Lerp(anim.GetFloat("Pressure"), pressure, .1f));
        if (Input.GetKeyDown("space"))
        {
            pressure -= pushStrength;
        }
        if (pressure > maxPressure)
        {
            Debug.Log("Fail");
            Fail();
        }else if (pressure < 0)
        {
            Debug.Log("Success");
            Success();
        }else if(currentTime > maxTime)
        {
            Debug.Log("PartialSuccess");
            PartialSuccess();
        }
    }
    private void Fail()
    {
        gameManager.Instance.ImplementResults(-10);
        Debug.Log(gameManager.Instance.fitnessPuntctuation);
        Destroy(this);
    }
    private void Success()
    {
        gameManager.Instance.ImplementResults(maxPunctuation);
        Debug.Log(gameManager.Instance.fitnessPuntctuation);
        Destroy(this);
    }
    private void PartialSuccess()
    {
        gameManager.Instance.ImplementResults(maxPunctuation * (1 - (pressure / 10)));
        Debug.Log(gameManager.Instance.fitnessPuntctuation);
        Destroy(this);
    }
}
