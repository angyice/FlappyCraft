using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceExpressionInstance : MonoBehaviour
{
    public ARFace MyFace;

    public Transform MaxDistanceDebug;

    Vector3[] standardFaceVertexPositions;
    Vector3[] openMouthFaceVertexPositions;


    // Start is called before the first frame update
    void Start()
    {
        FaceExpressionManager.Singleton.CurrentFaceInstance = this;
    }

    public void SetStandardFaceData()
    {
        standardFaceVertexPositions = MyFace.vertices.ToArray();
    }

    public void SetOpenMouthFaceData()
    {
        openMouthFaceVertexPositions = MyFace.vertices.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if(FaceExpressionManager.Singleton != null)
        {
            FaceExpressionManager.Singleton.MouthOpenValue = Mathf.Clamp01(Vector3.Distance(standardFaceVertexPositions[17], MyFace.vertices[17]) / 0.023f);
        }
        
    }


    void InterestingVertexDebug()
    {
        if (FaceExpressionManager.Singleton != null && standardFaceVertexPositions.Length != 0 && openMouthFaceVertexPositions.Length != 0)
        {
            int interestingVertex = 0;
            float interestingVertexMaxDistance = 0;

            for (int i = 0; i < standardFaceVertexPositions.Length; i++)
            {
                float currentDistance = Vector3.Distance(standardFaceVertexPositions[i], openMouthFaceVertexPositions[i]);
                if (currentDistance > interestingVertexMaxDistance)
                {
                    interestingVertex = i;
                    interestingVertexMaxDistance = currentDistance;
                }
            }


            MaxDistanceDebug.localPosition = MyFace.vertices[interestingVertex];
            FaceExpressionManager.Singleton.DebugText.text = interestingVertex.ToString() + " " + interestingVertexMaxDistance.ToString();
        }
    }
}
