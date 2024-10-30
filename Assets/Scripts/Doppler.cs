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
    private bool onButton = false;

    public bool Check()
    {
        switch (chooseVersion)
        {
            case Version.vs:
                if (vo != 0 && fs != 0 && fo != 0)
                {
                    calculateOnlyVs();
                    if (vs < 140 && vs > 1)
                    {
                        return true;
                    }
                    return false;
                }
                break;
            case Version.vo:
                if (vs != 0 && fs != 0 && fo != 0)
                {
                    calculateOnlyVo();
                    if (vo < 140 && vo > 0)
                    {
                        return true;
                    }
                    return false;
                }
                break;
            case Version.fo:
                if (vo != 0 && fs != 0 && vs != 0)
                {
                    calculateOnlyFo();
                    if (fo < 20000 && fo > 20)
                    {
                        return true;
                    }
                    return false;
                }
                break;
            case Version.fs:
                if (vo != 0 && fo != 0 && vs != 0)
                {
                    calculateOnlyFs();
                    if (fs < 20000 && fs > 20)
                    {
                        return true;
                    }
                    return false;
                }
                break;
        }
        return true;
    }

    public float getMinValueFs()
    {
        switch (chooseVersion)
        {
            case Version.vs:
                calculateFsWithVariable(vo, 1,fo);
                break;

            case Version.vo:
                calculateFsWithVariable(1,vs,fo);
                break;

            case Version.fo:
                calculateFsWithVariable(vo,vs,20);
                break;
        }
        return fs_;
    }
    public float getMaxValueFs()
    {
        switch (chooseVersion)
        {
            case Version.vs:
                calculateFsWithVariable(vo, 140, fo);
                break;

            case Version.vo:
                calculateFsWithVariable(140, vs, fo);
                break;

            case Version.fo:
                calculateFsWithVariable(vo, vs, 20000);
                break;
        }
        return fs_;
    }
    public float getMinValueFo()
    {
        switch (chooseVersion)
        {
            case Version.vs:
                calculateFoWithVariable(vo, 1, fs);
                break;

            case Version.vo:
                calculateFoWithVariable(1, vs, fs);
                break;

            case Version.fs:
                calculateFoWithVariable(vo, vs, 20);
                break;
        }
        return fo_;
    }
    public float getMaxValueFo()
    {
        switch (chooseVersion)
        {
            case Version.vs:
                calculateFoWithVariable(vo, 140, fs);
                break;

            case Version.vo:
                calculateFoWithVariable(140, vs, fs);
                break;

            case Version.fs:
                calculateFoWithVariable(vo, vs, 20000);
                break;
        }
        return fo_;
    }

    public float getMinValueVs()
    {
        switch (chooseVersion)
        {
            case Version.fo:
                calculateVsWithVariable(vo, fs, 20);
                break;

            case Version.vo:
                calculateVsWithVariable(1, fs, fo);
                break;

            case Version.fs:
                calculateVsWithVariable(vo, 20, fo);
                break;
        }
        return vs_;
    }
    public float getMaxValueVs()
    {
        switch (chooseVersion)
        {
            case Version.fo:
                calculateVsWithVariable(vo, fs, 20000);
                break;

            case Version.vo:
                calculateVsWithVariable(140, fs, fo);
                break;

            case Version.fs:
                calculateVsWithVariable(vo, 20000, fo);
                break;
        }
        return vs_;
    }

    public float getMinValueVo()
    {
        switch (chooseVersion)
        {
            case Version.fo:
                calculateVoWithVariable(fs, vs, 20);
                break;

            case Version.vs:
                calculateVoWithVariable(fs, 1, fo);
                break;

            case Version.fs:
                calculateVoWithVariable(20, vs, fo);
                break;
        }
        return vo_;
    }
    public float getMaxValueVo()
    {
        switch (chooseVersion)
        {
            case Version.fo:
                calculateVoWithVariable(fs, vs, 20000);
                break;

            case Version.vs:
                calculateVoWithVariable(fs, 140, fo);
                break;

            case Version.fs:
                calculateVoWithVariable(20000, vs, fo);
                break;
        }
        return vo_;
    }


    float fs_, fo_, vo_, vs_;
    public void calculateFsWithVariable(float vo, float vs, float fo)
    {
        if (s >= 0)
        {
            fs_ = fo * (v + vs) / (v + vo);
        }
        else
        {
            fs_ = fo * (v - vs) / (v - vo);
        }
    }
    public void calculateFoWithVariable(float vo, float vs, float fs)
    {
        if (s >= 0)
        {
            fo_ = (v + vo) / (v + vs) * fs;
        }
        else
        {
            fo_ = (v - vo) / (v - vs) * fs;
        }
    }
    public void calculateVsWithVariable(float vo, float fs, float fo)
    {
        if (s >= 0)
        {
            vs_ = fs * (v + vo) / fo - v;
        }
        else
        {
            vs_ = v - fs * (v - vo) / fo;
        }
    }
    public void calculateVoWithVariable(float fs, float vs, float fo)
    {
        if (s >= 0)
        {
            vo_ = fo * (v + vs) / fs - v;
        }
        else
        {
            vo_ = v - fo * (v - vs)/fs;
        }
    }
    public  void setButton()
    {
        onButton = !onButton;
    }

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
        if (onButton)
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
    }

    private void calculateOnlyVs()
    {
        if (s >= 0)
        {
            vs = fs * (v + vo) / fo - v;
        }
        else
        {
            vs = v - fs * (v - vo) / fo;
        }
    }
    private void calculateOnlyVo()
    {
        if (s >= 0)
        {
            vo = fo * (v + vs) / fs - v;
        }
        else
        {
            vo = v - fo * (v - vs) / fs;
        }
    }
    private void calculateOnlyFo()
    {
        if (s >= 0)
        {
            fo = (v + vo) / (v + vs) * fs;
        }
        else
        {
            fo = (v - vo) / (v - vs) * fs;
        }
    }
    private void calculateOnlyFs()
    {
        if (s >= 0)
        {
            fs = fo * (v + vs) / (v + vo);
        }
        else
        {
            fs = fo * (v - vs) / (v - vo);
        }
    }
    private void calculateVs()
    {
        float deltaTime = Time.deltaTime;
        if (vo != 0 && fs != 0 && fo != 0)
        {
            calculateOnlyVs();
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
            calculateOnlyVo();
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
            calculateOnlyFs();
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
            calculateOnlyFo();
            s += deltaTime * (vs - vo);
            tmp_s.text = tmp_s.name + " - " + Mathf.Abs(Mathf.Round(s)) + " m";
            result.text = result.name + " - " + Mathf.Round(fo) + "Hz";
            sound.GetComponent<AudioSimulator>().frequency = fo;
            sound.GetComponent<AudioSimulator>().sourceFrequency = fs;
            car.s = s;
        }
    }
    public float getfo()
    {
        return fo;
    }
    public float getvo()
    {
        return vo;

    }
    public float getfs()
    {
        return fs;
    }
    public float getvs()
    {
        return vs;
    }
}
