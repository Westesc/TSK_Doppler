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
    public Doppler doppler;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            tmp.text = tmp.name + " - " + v.ToString("0.") +" "+ unit;
            if (tmp.name == "vo")
            {
                doppler.SetVo(v); 
            }
            else if (tmp.name == "fs")
            {
                doppler.SetFs(v);
            }
            else if (tmp.name == "fo")
            {
                doppler.SetFo(v);
            }
            else if (tmp.name == "vs")
            {
                doppler.SetVs(v);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
