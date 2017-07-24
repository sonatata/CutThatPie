using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabManager : MonoBehaviour {
    // Assign the prefab in the inspector
    public GameObject PiePrefab;
    public GameObject bluepie;
    //Singleton
    private static prefabManager m_Instance = null;
    public static prefabManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (prefabManager)FindObjectOfType(typeof(prefabManager));
            }
            return m_Instance;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
