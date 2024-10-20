using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI tmp;
    public string unit;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            tmp.text = tmp.name + " - " + v.ToString("0.") +" "+ unit;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
