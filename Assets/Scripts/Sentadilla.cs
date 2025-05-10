using UnityEngine;

public class Sentadilla : MonoBehaviour
{
    public int pressure=35;
    public int pressureIncrease = 2;
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

        pressure += pressureIncrease;
        anim.SetInteger("Pressure", pressure);
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            pressure -= pushStrength;
        }
        if (pressure > maxPressure)
        {
            Fail();
        }else if (pressure > 0)
        {
            Success();
        }else if(currentTime > maxTime)
        {
            PartialSuccess();
        }
    }
    private void Fail()
    {
        gameManager.Instance.ImplementResults(-10); 
        Destroy(this);
    }
    private void Success()
    {
        gameManager.Instance.ImplementResults(maxPunctuation);
    }
    private void PartialSuccess()
    {
        gameManager.Instance.ImplementResults(maxPunctuation * (1 - (pressure / 100)));
    }
}
