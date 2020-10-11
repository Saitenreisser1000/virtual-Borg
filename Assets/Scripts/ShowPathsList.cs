using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShowPathsList : EditorWindow
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    [MenuItem("Tools/Path")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ShowPathsList));
    }

    private void OnGUI()
    {
        GUILayout.Label("Show Pathes", EditorStyles.boldLabel);
    }
}
