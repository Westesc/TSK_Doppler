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
    public AudioSource sound;
    [SerializeField] private TextMeshProUGUI tmp_s;
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] public Version chooseVersion;
    public enum Version
    {
        vs,
        vo,
        fo,
        fs
    }
    public Car car;

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

    public void SetVs(float value)
    {
        vs = value;
    }

    void Update()
    {
        switch (chooseVersion)
        {
            case Version.vs:
                calculateVs();
                break;

            case Version.vo:
                calculateVo();
                break;

            case Version.fo:
                calculateFo();
                break;

            case Version.fs:
                calculateFs();
                break;
        }
    }

    private void calculateVs()
    {
        float deltaTime = Time.deltaTime;
        if (vo != 0 && fs != 0 && fo != 0)
        {
            if (s >= 0)
            {
                vs = fs * (v + vo) / fo - v;
            }
            else
            {
                vs = v - fs * (v - vo) / fo;
            }
            s += deltaTime * (vs - vo);
            tmp_s.text = tmp_s.name + " - " + Mathf.Abs(Mathf.Round(s)) + " m";
            result.text = result.name + " - " + Mathf.Round(vs) + "m/s";
            car.s = s;
            sound.GetComponent<AudioSimulator>().frequency = fo;
            sound.GetComponent<AudioSimulator>().sourceFrequency = fs;
        }
    }

    private void calculateVo()
    {
        float deltaTime = Time.deltaTime;
        if (vs != 0 && fs != 0 && fo != 0)
        {
            if (s >= 0)
            {
                vo = fo * (v + vs) / fs - v;
            }
            else
            {
                vo = fo * (v - vs) / fs + v;
            }
            s += deltaTime * (vs - vo);
            tmp_s.text = tmp_s.name + " - " + Mathf.Abs(Mathf.Round(s)) + " m";
            result.text = result.name + " - " + Mathf.Round(vo) + "m/s";
            car.s = s;
            sound.GetComponent<AudioSimulator>().frequency = fo;
            sound.GetComponent<AudioSimulator>().sourceFrequency = fs;
        }
    }

    private void calculateFs()
    {
        float deltaTime = Time.deltaTime;
        if (vs != 0 && vo != 0 && fo != 0)
        {
            if (s >= 0)
            {
                fs = fo * (v + vs) / (v+vo);
            }
            else
            {
                fs = fo * (v - vs) / (v - vo);
            }
            s += deltaTime * (vs - vo);
            tmp_s.text = tmp_s.name + " - " + Mathf.Abs(Mathf.Round(s)) + " m";
            result.text = result.name + " - " + Mathf.Round(fs) + "Hz";
            car.s = s;
            sound.GetComponent<AudioSimulator>().frequency = fo;
            sound.GetComponent<AudioSimulator>().sourceFrequency = fs;
        }
    }

    private void calculateFo()
    {
        float deltaTime = Time.deltaTime;
        if (vo != 0 && fs != 0 && vs != 0)
        {
            if (s >= 0)
            {
                fo = (v + vo) / (v + vs) * fs;
            }
            else
            {
                fo = (v - vo) / (v - vs) * fs;
            }
            s += deltaTime * (vs - vo);
            tmp_s.text = tmp_s.name + " - " + Mathf.Abs(Mathf.Round(s)) + " m";
            result.text = result.name + " - " + Mathf.Round(fo) + "Hz";
            sound.GetComponent<AudioSimulator>().frequency = fo;
            sound.GetComponent<AudioSimulator>().sourceFrequency = fs;
            car.s = s;
        }
    }
}
