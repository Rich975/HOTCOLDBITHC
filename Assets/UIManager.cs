using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Ins;

    public TextMeshProUGUI distanceToTarget;
    public TextMeshProUGUI timeSpent;
    [SerializeField] float time;


    // Start is called before the first frame update
    void Start()
    {
        Ins = this;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void DisplayDistance(float distance)
    {
        distanceToTarget.text = distance.ToString("F0");
    }

    public void Timer()
    {
        timeSpent.text = (Time.time + Time.deltaTime).ToString("F0");
    }
}
