using UnityEditor;
using UnityEngine;
using System;

public class DateWizard : EditorWindow {
	
	#region User Settings
	ChronoEggSettings settings;
	#endregion
	
	#region Working fields
	Color timerColor = Color.green;
	Color backgroundColor = Color.green;
	DateTime myDate = DateTime.Now;
	
	#region time
	string[] Hours;
	int hourIndex = 0;
	string[] Minutes;
	int minuteIndex = 0;
	string[] Months;
	int monthIndex = 0;
	string ampm = "am";
	#endregion
	
	#region date
	string[] Years;
	int yearIndex = 0;
	int day = 1;
	#endregion
	
	#endregion
	
	void LoadSettings() {
		string editorPath = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this)));
		settings = AssetDatabase.LoadAssetAtPath(editorPath + "/settings.asset", typeof(ChronoEggSettings)) as ChronoEggSettings;
		if (settings == null) {
			settings = ScriptableObject.CreateInstance<ChronoEggSettings>();
			AssetDatabase.CreateAsset(settings, editorPath + "/settings.asset");
			AssetDatabase.SaveAssets();
		}
		myDate = settings.targetDate;
		timerColor = settings.textColor;
		backgroundColor = settings.backgroundColor;
	}
	
	void SaveSettings() {
		AssetDatabase.SaveAssets();
	}

	void ExtractDate()
	{
		day = myDate.Day;
		monthIndex = myDate.Month - 1;
		yearIndex = myDate.Year - DateTime.Now.Year;
		int hour = myDate.Hour;
		if (ChronoEqWindow.display24Hours) {
			hourIndex = hour;
		} else {
			if (hour == 0) {
				hourIndex = 11;
				ampm = "am"; // midnight is 12AM
			}
			else if (hour == 12) {
				hourIndex = 11;
				ampm = "pm"; // noon is 12PM
			}
			else if (hour > 12) {
				hourIndex = hour-13; // 13 is 1PM at index 0
				ampm = "pm"; // All above 12 is PM but between 1 and 11 (but index starts at 0)
			} else {
				ampm = "am"; // Everything else (below 12) is AM
			}
		}
		//hourIndex = Array.IndexOf(Hours, hour);
		minuteIndex = myDate.Minute;
	}
	
	void UpdateDate()
	{
		string ampmStr = (ChronoEqWindow.display24Hours ? "" : ampm);
		string deadlineTime = string.Format("{0:00}:{1:00} {2}", Hours[hourIndex], minuteIndex, ampmStr);
		string dateFormatted = "" + (DateTime.Now.Year + yearIndex) + "/" + (monthIndex + 1) + "/" + day + " " + deadlineTime;
		DateTime.TryParse(dateFormatted, out myDate);
	}

	void OnEnable() {
		// Fill an array with the names of the months
		Months = new string[12];
		DateTime iMonth = new DateTime(DateTime.Now.Year, 1, 1);
		for (int i = 0; i < 12; i++) {
			Months[i] = iMonth.ToString("MMMM");
			iMonth = iMonth.AddMonths(1);
		}
		
		// Show the next 10 years
		Years = new string[10];
		for (int i = 0; i < 10; i++)
			Years[i] = "" + (DateTime.Now.Year + i);
		// Build the hour list
		int start = (ChronoEqWindow.display24Hours ? 0 : 1);
		int end = (ChronoEqWindow.display24Hours ? 23 : 12);
		Hours = new string[end-start+1];
		for (int i = start; i <= end; i++)
			Hours[i-start] = "" + i;
		// Build the minutes list
		Minutes = new string[60];
		for (int i = 0; i < 60; i++)
			Minutes[i] = string.Format("{0:00}", i);
		
		LoadSettings();
		
		ExtractDate();
	}

	
	void ApplySettings() {
		settings.backgroundColor = backgroundColor;
		settings.textColor = timerColor;
		
		UpdateDate();
		
		settings.targetDate = myDate;
		SaveSettings();
		// Update in the main window
		ChronoEqWindow.ApplySettings();
		// Close the settings window
		Close();
	}

	void OnGUI() {
		// Set window fixed size
		Rect dimension = this.position;
		dimension.width = 420;
		dimension.height = 200;
		this.position = dimension;

		// Colors
		GUILayout.BeginHorizontal(EditorStyles.toolbar);
		GUILayout.Label("Colors", EditorStyles.boldLabel, GUILayout.ExpandWidth(true));
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Space(12);
		EditorGUILayout.PrefixLabel("Background");
		backgroundColor = EditorGUILayout.ColorField("", backgroundColor);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Space(12);
		EditorGUILayout.PrefixLabel("Text");
		timerColor = EditorGUILayout.ColorField("", timerColor);
		GUILayout.EndHorizontal();

		// Count down dead line
		GUILayout.BeginHorizontal(EditorStyles.toolbar);
		GUILayout.Label("Countdown dead line", EditorStyles.boldLabel, GUILayout.ExpandWidth(true));
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Space(12);
		EditorGUILayout.PrefixLabel("Target Date");
		day = EditorGUILayout.IntField(day, GUILayout.Width(32));
		if (day < 1)
			day = 1;
		else if (day > 31)
			day = 31;
		monthIndex = EditorGUILayout.Popup(monthIndex, Months, GUILayout.ExpandWidth(false));
		yearIndex = EditorGUILayout.Popup(yearIndex, Years, GUILayout.ExpandWidth(false));
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Space(12);
		EditorGUILayout.PrefixLabel("Target Time");
		hourIndex = EditorGUILayout.Popup(hourIndex, Hours, GUILayout.ExpandWidth(false));
		GUILayout.Label(":", GUILayout.ExpandWidth(false));
		minuteIndex = EditorGUILayout.Popup(minuteIndex, Minutes, GUILayout.ExpandWidth(false));
		
		if (!ChronoEqWindow.display24Hours) {
			int index = GUILayout.Toolbar((ampm.Equals("pm") ? 1 : 0), new string[] {"AM", "PM"});
			if (index == 0)
				ampm = "am";
			else
				ampm = "pm";
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		// Dead line shortcuts
		GUILayout.Space(4);
		GUILayout.BeginHorizontal();
		GUILayout.Space(12);
		GUILayout.Label("Short cuts", EditorStyles.boldLabel);
			if (GUILayout.Button("+4h", EditorStyles.toolbarButton)) {
				myDate = DateTime.Now.AddHours(4);
				ExtractDate();
			}
			if (GUILayout.Button("+24h", EditorStyles.toolbarButton)) {
				myDate = DateTime.Now.AddHours(24);
				ExtractDate();
			}
			if (GUILayout.Button("+48h", EditorStyles.toolbarButton)) {
				myDate = DateTime.Now.AddHours(48);
				ExtractDate();
			}
			if (GUILayout.Button("+72h", EditorStyles.toolbarButton)) {
				myDate = DateTime.Now.AddHours(72);
				ExtractDate();
			}
			if (GUILayout.Button("+1m", EditorStyles.toolbarButton)) {
				myDate = DateTime.Now.AddMonths(1);
				ExtractDate();
			}
			if (GUILayout.Button("+1y", EditorStyles.toolbarButton)) {
				myDate = DateTime.Now.AddYears(1);
				ExtractDate();
			}
		GUILayout.EndHorizontal();
		
		// Space
		GUILayout.FlexibleSpace();
		
		// Apply / Cancel
		GUILayout.BeginHorizontal();
		Color wasColor = GUI.color;
		GUILayout.FlexibleSpace();
		GUI.color = Color.green;
		if (GUILayout.Button("Apply", GUILayout.ExpandWidth(false))) {
			ApplySettings();
		}
		GUI.color = Color.red;
		if (GUILayout.Button("Cancel", GUILayout.ExpandWidth(false))) {
			Close();
		}
		GUI.color = wasColor;
		GUILayout.EndHorizontal();
	}
}
