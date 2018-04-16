using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
    public double[] input;
    public double output;
}
public class Percepton : MonoBehaviour {
    public TrainingSet[] ts;
    double[] weight = { 0, 0 };
    double bias = 0;
    double totalError = 0;
    double DotProductBias(double[] v1,double[] v2)
    {
        if(v1==null || v2==null)
        {
            return -1;
        }
        if (v1.Length != v2.Length) return -1;
        double d = 0;
        for(int i=0;i<v1.Length;i++)
        {
            d += v1[i] * v2[i];
        }
        d += bias;
        return d;
    }
    double CalcOutput(int i)
    {
        double dp = DotProductBias(weight, ts[i].input);
        if (dp > 0) return 1;
        else return 0;
    }
    void InitialiseWeights()
    {
        for(int i=0;i<weight.Length;i++)
        {
            weight[i] = Random.Range(-1.0f, 1.0f);
        }
        bias = Random.Range(-1.0f, 1.0f);
    }
    void UpdateWeights(int j)
    {
        double error = ts[j].output - CalcOutput(j);
        totalError += Mathf.Abs((float)error);
        for(int i=0;i<weight.Length;i++)
        {
            weight[i] = weight[i] + error * ts[j].input[i];
        }
        bias += error;
    }
    void Train(int epochs)
    {
        InitialiseWeights();
        for(int e=0;e<epochs;e++)
        {
            totalError = 0;
            for(int t=0;t<ts.Length;t++)
            {
                UpdateWeights(t);
                Debug.Log("W1: " + weight[0] + " W2: " + weight[1] + " bias: " + bias);
            }
            Debug.Log("Total Error: " + totalError);
        }
    }

    private void Start()
    {
        Train(8);   
    }
}
