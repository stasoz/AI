using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Riding : MonoBehaviour
{
    public float speed = 50.0F;
    public float rotationSpeed = 100.0F;
    public float visibleDistance = 200.0f;
    List<string> collectedTrainingData = new List<string>();
    StreamWriter tdf;
     
    private void Start()
    {
        string path = Application.dataPath + "/trainingData.txt";
        tdf = File.CreateText(path);
    }

    private void OnApplicationQuit()
    {
        foreach(string td in collectedTrainingData)
        {
            tdf.WriteLine(td);
        }
        tdf.Close();
    }
    float Round(float x)
    {
        return (float)System.Math.Round(x, System.MidpointRounding.AwayFromZero) / 2.0f;
    }
    private void Update()
    {
        float translationInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");
        float translation = Time.deltaTime*speed*translationInput;
        float rotation = Time.deltaTime*rotationSpeed*rotationInput;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        Debug.DrawRay(transform.position, this.transform.forward * visibleDistance, Color.red);
        Debug.DrawRay(transform.position, this.transform.right * visibleDistance, Color.red);

        RaycastHit hit;
        float fDist = 0, rDist =0, lDist = 0, r45Dist = 0, l45Dist = 0;


        //info//
        if(Physics.Raycast(transform.position,this.transform.forward,out hit,visibleDistance))
        {
            fDist = Round(1-hit.distance/visibleDistance);
        }
        if (Physics.Raycast(transform.position, this.transform.right, out hit, visibleDistance))
        {
            rDist = Round(1 - hit.distance / visibleDistance);
        }
        if (Physics.Raycast(transform.position, -this.transform.right, out hit, visibleDistance))
        {
            lDist = Round(1 - hit.distance / visibleDistance);
        }
        if (Physics.Raycast(transform.position, Quaternion.AngleAxis(45,Vector3.up)*this.transform.right, out hit, visibleDistance))
        {
            r45Dist = Round(1 - hit.distance / visibleDistance);
        }
        if (Physics.Raycast(transform.position, Quaternion.AngleAxis(45, Vector3.up) * -this.transform.right, out hit, visibleDistance))
        {
            l45Dist = Round(1 - hit.distance / visibleDistance);
        }
        string td = fDist + " , " + rDist + " , " + lDist + " , " + r45Dist + " , " + l45Dist + " , " + Round(translationInput) + " , " + Round(rotationInput);
        if (!collectedTrainingData.Contains(td))
        {
            collectedTrainingData.Add(td);
        }
    }
}
