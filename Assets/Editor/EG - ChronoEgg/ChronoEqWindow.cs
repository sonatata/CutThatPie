using UnityEngine;
using UnityEditor;
using System;
using System.Globalization;

public class ChronoEqWindow : EditorWindow {

	private static string VERSION = "1.1";
	private static int BUTTON_SIZE = 32;
	
	#region settings
	ChronoEggSettings settings = null;
	#endregion

	#region runtime fields
	DateTime nextFontCalculation = DateTime.Now;
	float fontCalculationDelay = 0.5f;
	public static bool display24Hours;
	
		#region chronometer
		private DateTime startChronometer = DateTime.Now;
		private TimeSpan currentElapsedTime = new TimeSpan(0);
		private TimeSpan alreadyElapsedTime = new TimeSpan(0);
		#endregion
	
		#region countdown
		public static TimeSpan countDownDefault;
		private float remainingSeconds = 0;
		#endregion
	
	private float presetButtonHeight = 10;
	
	private ChronoStatus currentStatus = ChronoStatus.paused;
	private ChronoKind currentKind = ChronoKind.chronometer;
	#endregion
	
	#region display runtime fields
	private static GUIStyle myStyle;
	public Texture2D backgroundTexture;
	private string scriptPath;
	
	private Rect lastPosition;
	private string firstLine;
	private string secondLine;
	
	private DateTime nextUpdate = DateTime.Now;
	private float updateDelay = 0.25f;
	#endregion
	
	private static ChronoEqWindow _instance;
	public static ChronoEqWindow Instance { get { 	if (_instance == null) _instance = EditorWindow.GetWindow<ChronoEqWindow>(); return _instance; } }

	[MenuItem("Window/Equilibre/ChronoEgg")]
	static void OpenWindow() {
		Instance.Show();
	}
	
	void OnEnable() {
		Initialize(false);
	}
	
	public static void ApplySettings() {
		Instance.Initialize(true);
	}
	
	void LoadSettings() {
		string editorPath = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this)));
		settings = AssetDatabase.LoadAssetAtPath(editorPath + "/settings.asset", typeof(ChronoEggSettings)) as ChronoEggSettings;
		if (settings == null) {
			settings = ScriptableObject.CreateInstance<ChronoEggSettings>();
			AssetDatabase.CreateAsset(settings, editorPath + "/settings.asset");
			AssetDatabase.SaveAssets();
			//Debug.Log("Settings created at path " + editorPath + "/settings.asset");
		}
	}
	
	void SaveSettings() {
		AssetDatabase.SaveAssets();
	}
	
	void Initialize(bool forceUpdate) {
		if (settings == null) {
			LoadSettings();
		}
		if (backgroundTexture == null || forceUpdate) {
			CreateBackground();
		}
		if (myStyle == null || forceUpdate) {
			myStyle = new GUIStyle();
			myStyle.alignment = TextAnchor.MiddleCenter;
			CalculateFontSize();
		}
		// Should we display 24Hours ? Use Current System Info
		display24Hours = (DateTimeFormatInfo.CurrentInfo.AMDesignator.Equals(""));
	}

	void Reset() {
		if (settings == null) {
			LoadSettings();
		}
		if (settings != null) {
			settings.status = ChronoStatus.running;
			settings.kind = ChronoKind.chronometer;
			// Default target time is 48 hours for Ludum Dare !
			settings.targetDate = DateTime.Now.AddDays(2);
			// Default colors = cyan on black
			settings.textColor = Color.cyan;
			settings.backgroundColor = Color.black;
			CreateBackground();
		}
		
		firstLine = "I'm";
		secondLine = "here";

	}

	/// <summary>
	/// Create the background texture
	/// </summary>
	public void CreateBackground() {
		backgroundTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
		backgroundTexture.SetPixel(0, 0, settings.backgroundColor);
		backgroundTexture.wrapMode = TextureWrapMode.Repeat;
		backgroundTexture.filterMode = FilterMode.Point;
		backgroundTexture.Apply();
	}

	void OnGUI() {
		
		if (backgroundTexture == null || !backgroundTexture.GetPixel(0, 0).Equals(settings.backgroundColor)) {
			CreateBackground();
		}
		if (scriptPath == null || scriptPath.Length == 0) {
			scriptPath = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this)));
		}
		presetButtonHeight = GUI.skin.button.CalcSize(new GUIContent("+24")).y;
		
		title = "ChronoEgg " + VERSION;
		
		ChronoKind previousKind = settings.kind;
		
		// Set minimum size for buttons
		this.minSize = new Vector2(BUTTON_SIZE*3, BUTTON_SIZE*4);
		
		// Draw background flat color from settings
		Rect backgroundRect = new Rect(0, 0, this.position.width, this.position.height);
		GUI.DrawTexture(backgroundRect, backgroundTexture);
		
		GUILayout.BeginHorizontal();
		// First Column : Kind choice (chronometer, count down, date time) + settings
		GUILayout.BeginVertical();
		bool chronometer = GUILayout.Toggle((currentKind == ChronoKind.chronometer), AssetDatabase.LoadAssetAtPath (scriptPath + "/icons/chronometer.png", typeof(Texture)) as Texture, "button", GUILayout.Width(BUTTON_SIZE), GUILayout.Height(BUTTON_SIZE));
		if (chronometer && GUI.changed) {
			currentKind = ChronoKind.chronometer;
			SaveSettings();
		}
		bool countdown = GUILayout.Toggle((currentKind == ChronoKind.countdown), AssetDatabase.LoadAssetAtPath (scriptPath + "/icons/countdown.png", typeof(Texture)) as Texture, "button", GUILayout.Width(BUTTON_SIZE), GUILayout.Height(BUTTON_SIZE));
		if (countdown && GUI.changed) {
			currentKind = ChronoKind.countdown;
			currentStatus = ChronoStatus.running;
			SaveSettings();
			// Ensure the countdown timer is updated
			CalculateRemainingSeconds();
		}
		bool datetime = GUILayout.Toggle((currentKind == ChronoKind.datetime), AssetDatabase.LoadAssetAtPath (scriptPath + "/icons/datetime.png", typeof(Texture)) as Texture, "button", GUILayout.Width(BUTTON_SIZE), GUILayout.Height(BUTTON_SIZE));
		if (datetime && GUI.changed) {
			currentKind = ChronoKind.datetime;
			SaveSettings();
		}
		if (GUILayout.Button(AssetDatabase.LoadAssetAtPath (scriptPath + "/icons/settings.png", typeof(Texture)) as Texture, GUILayout.Width(BUTTON_SIZE), GUILayout.Height(BUTTON_SIZE))) {
			EditorWindow.GetWindowWithRect(typeof(DateWizard), new Rect(100, 100, 300, 180), true, "Chrono Egg Settings");
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		
		// 2nd column for chronometer : play/pause, restart
		if (currentKind == ChronoKind.chronometer) {
		GUILayout.BeginVertical();
		if (GUILayout.Button(AssetDatabase.LoadAssetAtPath (scriptPath + "/icons/" + (currentStatus == ChronoStatus.running ? "pause" : "play") + ".png", typeof(Texture)) as Texture, "button", GUILayout.Width(BUTTON_SIZE), GUILayout.Height(BUTTON_SIZE))) {
			if (currentStatus == ChronoStatus.running) {
					currentStatus = ChronoStatus.paused;
					// Store the already elapsed time
					alreadyElapsedTime = currentElapsedTime;
				} else {
					currentStatus = ChronoStatus.running;
					// Reset datetime start (already elapsed time has been stored)
					startChronometer = DateTime.Now;
				}
		}
		if (GUILayout.Button(AssetDatabase.LoadAssetAtPath (scriptPath + "/icons/reset.png", typeof(Texture)) as Texture, "button", GUILayout.Width(BUTTON_SIZE), GUILayout.Height(BUTTON_SIZE))) {
			alreadyElapsedTime = new TimeSpan(0);
			currentElapsedTime = new TimeSpan(0);
			startChronometer = DateTime.Now;
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		}
		
		// Set content lines
		firstLine = "";
		secondLine = "";
		switch (currentKind) {
		case ChronoKind.countdown:
			GUICountdown();
			break;
		case ChronoKind.chronometer:
			GUIChronometer();
			break;
		case ChronoKind.datetime:
			GUIClock();
			break;
		}
		
		// Update font size if resized or kind change
		if (currentKind != previousKind || !this.position.Equals(lastPosition))
			CalculateFontSize();
		
		settings.kind = currentKind;
		
		// 3rd column with presets buttons and content lines
		myStyle.normal.textColor = settings.textColor;
		GUILayout.BeginVertical();
		if (currentKind == ChronoKind.countdown) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("+4")) {
				settings.targetDate = DateTime.Now.AddHours(4);
			}
			if (GUILayout.Button("+24")) {
				settings.targetDate = DateTime.Now.AddHours(24);
			}
			if (GUILayout.Button("+48")) {
				settings.targetDate = DateTime.Now.AddHours(48);
			}
			if (GUILayout.Button("+72")) {
				settings.targetDate = DateTime.Now.AddHours(72);
			}
			if (GUILayout.Button("+1m")) {
				settings.targetDate = DateTime.Now.AddMonths(1);
			}
			if (GUILayout.Button("+1y")) {
				settings.targetDate = DateTime.Now.AddYears(1);
			}
			GUILayout.EndHorizontal();
		}
		if (firstLine.Length > 0) {
			Rect firstLineRect = GUILayoutUtility.GetRect(new GUIContent(firstLine), myStyle, GUILayout.ExpandWidth(true));
			GUI.Label(firstLineRect, firstLine, myStyle);
		}
		Rect secondLineRect = GUILayoutUtility.GetRect(new GUIContent(secondLine), myStyle, GUILayout.ExpandWidth(true));
		GUI.Label(secondLineRect, secondLine, myStyle);
		GUILayout.EndVertical();

		GUILayout.EndHorizontal();
	}
	
	/// <summary>
	/// Set content lines for countdown
	/// </summary>
	private void GUICountdown() {
		// display the countdown timer
		if (remainingSeconds < 0) {
			firstLine = "That moment";
			secondLine = "has past.";
			return;
		}
		int roundedRestSeconds = Mathf.CeilToInt(remainingSeconds);
		int displaySeconds = roundedRestSeconds % 60;
		int displayMinutes = Mathf.CeilToInt(roundedRestSeconds / 60) % 60;
		roundedRestSeconds -= displayMinutes * 60;
		int displayHours = Mathf.CeilToInt(roundedRestSeconds / 3600) % 24;
		roundedRestSeconds -= displayHours * 3600;
		int displayDays = Mathf.CeilToInt(roundedRestSeconds / 86400) % 31;
		roundedRestSeconds -= displayDays * 86400;
		int displayMonths = Mathf.CeilToInt(roundedRestSeconds / 2629800);
		roundedRestSeconds -= displayMonths * 2629800;
		int displayYears = Mathf.CeilToInt(roundedRestSeconds / 31557600);
		
		firstLine = "";
		if (displayYears > 0)
			firstLine += string.Format("{0}y", displayYears);
		if (displayMonths > 0)
			firstLine += string.Format ("{0}m", displayMonths);
		if (displayDays > 0)
			firstLine += string.Format ("{0}d", displayDays);
		secondLine = string.Format("{0:00}:{1:00}:{2:00}", displayHours, displayMinutes, displaySeconds);
	}
	
	/// <summary>
	/// Set content lines for chronometer
	/// </summary>
	private void GUIChronometer() {
		firstLine = string.Format("{0:00}:{1:00}:{2:00}", currentElapsedTime.Hours, currentElapsedTime.Minutes, currentElapsedTime.Seconds);
		secondLine = string.Format("{0:000} ms", currentElapsedTime.Milliseconds);
	}
	
	/// <summary>
	/// Set content lines for datetime
	/// </summary>
	private void GUIClock() {
		DateTime now = DateTime.Now;
		firstLine = now.ToShortDateString();
		secondLine = now.ToShortTimeString();
	}

	/// <summary>
	/// Calculates the size of the font from the current mode and window size
	/// </summary>
	void CalculateFontSize() {
		if (DateTime.Now.CompareTo(nextFontCalculation) < 0)
			return;
			
		nextFontCalculation = DateTime.Now.AddSeconds(fontCalculationDelay);
		bool foundRatio = false;
		Rect container = this.position;
		// substract the buttons column width
		container.width -= BUTTON_SIZE;
		// substract the second buttons column width when set on chronometer
		if (currentKind == ChronoKind.chronometer)
			container.width -= BUTTON_SIZE;
		// substract presets line height
		else if (currentKind == ChronoKind.countdown)
			container.height -= presetButtonHeight;
		if (firstLine != null && firstLine.Length > 0)
			container.height /= 2;
		// TODO improve average calculation : it's slow if you use a huge window
		// calculate a average maximum font size
		int widthSize = Mathf.FloorToInt(this.position.width / 5f);
		int heightSize = Mathf.FloorToInt((this.position.height - 32) / 2f);
		// When modifying the window, the style can be lost
		myStyle.fontSize = Mathf.Max(widthSize, heightSize);
		do {
			myStyle.fontSize--;
			Vector2 styleSize = Vector2.one * 10;
			try {
				styleSize = myStyle.CalcSize(new GUIContent(firstLine));
			} catch (Exception ex) {
				Debug.Log("Sometimes, Unity can't calculate the size of a large label once (" + ex.ToString() + ")");
			}
			Vector2 secondStyleSize = Vector2.one * 10;
			try {
				secondStyleSize = myStyle.CalcSize(new GUIContent(secondLine));
			} catch (Exception ex) {
				Debug.Log("Sometimes, Unity can't calculate the size of a large label once (" + ex.ToString() + ")");
			}
			float minWidth = Mathf.Max(styleSize.x, secondStyleSize.x);
			float minHeight = Mathf.Max(styleSize.y, secondStyleSize.y);
			if ((container.height > minHeight && container.width > minWidth) || myStyle.fontSize <= 6) {
				foundRatio = true;
			}
		} while (!foundRatio);
		lastPosition = this.position;
	}
	
	void CalculateRemainingSeconds() {
		remainingSeconds = (float) settings.targetDate.Subtract(DateTime.Now).TotalSeconds;
	}
	
	/// <summary>
	/// Update the countdown or chronometer elapsed time and repaint (not too much)
	/// </summary>
	void Update() {
		if (DateTime.Now.CompareTo(nextUpdate) > 0) {
			nextUpdate = DateTime.Now.AddSeconds(updateDelay);
			Repaint();
		}
		if (currentStatus == ChronoStatus.running) {
			switch(currentKind) {
			case ChronoKind.chronometer:
				currentElapsedTime = DateTime.Now.Subtract(startChronometer) + alreadyElapsedTime; break;
			case ChronoKind.countdown:
				CalculateRemainingSeconds(); break;
			}
		}
	}
}
