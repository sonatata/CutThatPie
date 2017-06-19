using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour 
{
	public static bool is_cut = false;
	public static string cut_frac = "0";

	void Awake() {
		DontDestroyOnLoad (this);
	}

}