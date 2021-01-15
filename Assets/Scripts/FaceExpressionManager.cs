using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceExpressionManager : MonoBehaviour
{
    public static FaceExpressionManager Singleton;

    public FaceExpressionInstance CurrentFaceInstance;

    public float MouthOpenValue;

    public Text DebugText;

    private void OnEnable()
    {
        Singleton = this;
    }


    public void SetStandardFaceData()
    {
        if (CurrentFaceInstance != null)
        {
            CurrentFaceInstance.SetStandardFaceData();
        }
    }

    public void SetOpenMouthFaceData()
    {
        if (CurrentFaceInstance != null)
        {
            CurrentFaceInstance.SetOpenMouthFaceData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugText.text = MouthOpenValue.ToString();
    }
}
