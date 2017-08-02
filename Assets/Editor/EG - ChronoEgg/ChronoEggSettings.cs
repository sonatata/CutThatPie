using UnityEngine;
using System;
using System.Collections;

#region enumerations
	public enum ChronoKind {
		countdown,
		chronometer,
		datetime
	}
	
	public enum ChronoStatus {
		running,
		paused
	}
	#endregion

[System.SerializableAttribute]
public class ChronoEggSettings : ScriptableObject {
	
	public DateTime targetDate { get { return DateTime.FromOADate(targetTime); } set { targetTime = value.ToOADate(); } }
	[SerializeField]
	private double targetTime = DateTime.Now.ToOADate();
	public Color textColor = Color.green;
	public Color backgroundColor = Color.black;
	public ChronoStatus status = ChronoStatus.paused;
	public ChronoKind kind = ChronoKind.datetime;
}