using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Description : MonoBehaviour
{
    [Header("These descriptions are for organization only.")]
    public string modifyDescription;
    public bool ResetDescription;
    [SerializeField] string SerializedDescription;
    private void Update()
    {
        if (ResetDescription)
            SetDescription(modifyDescription);
    }

    void SetDescription (string description)
    {
        SerializedDescription = description;
        ResetDescription = false;
}
}
