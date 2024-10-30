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
    private float previousFs = 0;
    private float previousFo = 0;
    private float previousVs = 0;
    private float previousVo = 0;
    float min = 0;
    float max = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            tmp.text = tmp.name + " - " + v.ToString("0.") + " " + unit;
            if (tmp.name == "vo")
            {
                doppler.SetVo(v);
                if (!doppler.Check())
                {
                    min = doppler.getMinValueVo();
                    max = doppler.getMaxValueVo();
                    if (Mathf.Abs(v - max) > Mathf.Abs(v - min))
                    {
                        previousVo = min;
                    }
                    else
                    {
                        Debug.Log("prze³aczam na max");
                        previousVo = max;
                    }
                    if ((min < 1 || min > 140) && (max < 1 || max > 140))
                    {
                        min = doppler.getMinValueFs();
                        max = doppler.getMaxValueFs();
                        if (Mathf.Abs(v - max) > Mathf.Abs(v - min))
                        {
                            previousFs = min;
                        }
                        else
                        {
                            previousFs = max;
                        }
                        doppler.SetFs(previousFs);
                        //slider.value = previousFs;
                        Slider slider = GameObject.Find("Slider fs")?.GetComponent<Slider>();
                        slider.value = previousFs;
                        //GameObject objectFs = GameObject.Find("Slider fs");
                       
                    }
                    else
                    {
                        doppler.SetVo(previousVo);
                        slider.value = previousVo;
                    }
                }
                else
                {
                    previousVo = v;
                }
            }
            else if (tmp.name == "fs")
            {
                doppler.SetFs(v);
                if (!doppler.Check())
                {
                    min = doppler.getMinValueFs();
                    max = doppler.getMaxValueFs();
                    if (Mathf.Abs(v - max) > Mathf.Abs(v - min))
                    {
                        previousFs = min;
                    }
                    else
                    {
                        previousFs = max;
                    }
                    doppler.SetFs(previousFs);
                    slider.value = previousFs;
                }
                else
                {
                    previousFs = v;
                }
            }
            else if (tmp.name == "fo")
            {
                doppler.SetFo(v);
                if (!doppler.Check())
                {
                    min = doppler.getMinValueFo();
                    max = doppler.getMaxValueFo();
                    if (Mathf.Abs(v - max) > Mathf.Abs(v - min))
                    {
                        previousFo = min;
                    }
                    else
                    {
                        previousFo = max;
                    }
                    doppler.SetFo(previousFo);
                    slider.value = previousFo;
                }
                else
                {
                    previousFo = v;
                }
            }
            else if (tmp.name == "vs")
            {
                doppler.SetVs(v);
                if (!doppler.Check())
                {
                    min = doppler.getMinValueVs();
                    max = doppler.getMaxValueVs();
                    if (Mathf.Abs(v - max) > Mathf.Abs(v - min))
                    {
                        previousVs = min;
                    }
                    else
                    {
                        previousVs = max;
                    }

                    if ((min < 1 || min > 140) && (max < 1 || max > 140))
                    {
                        min = doppler.getMinValueFs();
                        max = doppler.getMaxValueFs();
                        if (Mathf.Abs(v - max) > Mathf.Abs(v - min))
                        {
                            previousFs = min;
                        }
                        else
                        {
                            previousFs = max;
                        }
                        doppler.SetFs(previousFs);
                        Slider slider = GameObject.Find("Slider fs")?.GetComponent<Slider>();
                        slider.value = previousFs;
                    }
                    else
                    {
                        doppler.SetVs(previousVs);
                        slider.value = previousVs;
                    }
                }
                else
                {
                    previousVs = v;
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

