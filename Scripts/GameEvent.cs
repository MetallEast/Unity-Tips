using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Custom/ScriptableObjects/Game Event")]
public class GameEvent : ScriptableObject
{
#if UNITY_EDITOR
	[SerializeField] bool debugMode;
	[SerializeField] string description;
#endif
	List<Action> listeners = new List<Action>();

	public void Raise()
	{
#if UNITY_EDITOR
		if (debugMode)
			Debug.Log(name + " raised. Listeners: " + listeners.Count);
#endif
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].Invoke();
	}

	public void AddListener(Action listener)
	{
#if UNITY_EDITOR
		if (debugMode)
			Debug.Log("Added listener: " + listener.Method.Name);
#endif
		listeners.Add(listener);
	}

	public void RemoveListener(Action listener)
	{
#if UNITY_EDITOR
		if (debugMode)
			Debug.Log("Removed listener: " + listener.Method.Name);
#endif
		listeners.Remove(listener);
	}
}