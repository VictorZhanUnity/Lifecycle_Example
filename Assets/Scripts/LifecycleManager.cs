using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifecycleManager : MonoBehaviour
{
    [SerializeField] private Text txtOutput;
    private bool isFixedUpdate = false, isUpdate = false, isLateUpdate = false, isOnDrawGizmos = false, isOnGUI = false;
    
    #region {Unity Lifecycle Funcation}
    private void OnApplicationFocus(bool focus) => Output("OnApplicationFocus:" + focus);
    private void Reset () => Output("Reset");
    private void Awake () => Output("Awake");
    void Start () => Output("Start");
    private void OnEnable () => Output("OnEnable");
    private void FixedUpdate()
    {
        if (!isFixedUpdate)
        {
            isFixedUpdate = true;
            Output("FixedUpdate");
        }
    }
    private void Update ()
    {
        if (!isUpdate)
        {
            isUpdate = true;
            Output("Update");
        }
    }
    private void LateUpdate ()
    {
        if (!isLateUpdate)
        {
            isLateUpdate = true;
            Output("LateUpdate");
        }
    }
    private void OnWillRenderObject () => Output("OnWillRenderObject");
    private void OnPreCull () => Output("OnPreCull");
    private void OnBecameVisible () => Output("OnBecameVisible");
    private void OnBecameInvisible () => Output("OnBecameInvisible");
    private void OnPreRender () => Output("OnPreRender");
    private void OnPostRender () => Output("OnPostRender");
    private void OnRenderImage(RenderTexture source, RenderTexture destination) => Output("OnRenderImage");
    private void OnDrawGizmos ()
    {
        if (!isOnDrawGizmos)
        {
            isOnDrawGizmos = true;
            Output("OnDrawGizmos");
        }
    }
    private void OnGUI ()
    {
        if (!isOnGUI)
        {
            isOnGUI = true;
            Output("OnGUI");
        }
    }
    private void OnApplicationPause(bool pause) => Output("OnApplicationPause:" + pause);
    private void OnDisable () => Output("OnDisable");
    private void OnDestroy () => Output("OnDestroy");
    private void OnApplicationQuit () => Output("OnApplicationQuit");
    #endregion

    public void ClearMessage()
    {
        txtOutput.transform.position = new Vector2(txtOutput.transform.position.x, 0);
        txtOutput.text = "";
    }
    private void Output(string msg)
    {
        txtOutput.text += $"¡i{DateTime.Now.ToString("hh:mm:ss")}¡jState¡G{msg}\n";
    }

    [ContextMenu("-Find All Parameters")]
    private void FindAllParameters()
    {
        txtOutput = GameObject.Find("Text_Output").GetComponent<Text>();
        txtOutput.text = "";
    }
}