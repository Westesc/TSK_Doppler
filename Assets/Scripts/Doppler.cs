using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doppler : MonoBehaviour
{
    private float vo;
    private float vs;
    private float v = 340;
    private float fs;
    private float fo;
    private float s = 0;
    [SerializeField] private TextMeshProUGUI tmp_s;
    [SerializeField] private TextMeshProUGUI tmp_vs;

    public void SetVo(float value)
    {
        vo = value;
    }

    // Metoda do ustawienia wartoœci vs
    public void SetFs(float value)
    {
        fs = value;
    }

    public void SetFo(float value)
    {
        fo = value;
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;
        if (vo != 0 && fs != 0 && fo != 0) {
            if (s >= 0)
            {
                vs = fs * (v + vo) / fo - v;
            }
            else
            {
                vs = v - fs * (v - vo) / fo;
            }
            s += deltaTime * (vs - vo);
            tmp_s.text = tmp_s.name + " - " + Mathf.Round(s);
            tmp_vs.text = tmp_vs.name + " - " + Mathf.Round(vs); ;
        }
    }
}
