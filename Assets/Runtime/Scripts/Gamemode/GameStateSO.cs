using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public enum GameState
{
	Gameplay, //regular state: player moves, attacks, can perform actions
	Pause, //pause menu is opened, the whole game world is frozen
	Cutscene
}

[CreateAssetMenu(fileName = "GameState", menuName = "Gameplay/GameState", order = 51)]
public class GameStateSO : SerializableScriptableObject
{
	public GameState CurrentGameState => _currentGameState;
	
	[Header("Game states")]
	[SerializeField][ReadOnly] private GameState _currentGameState = default;
	[SerializeField][ReadOnly] private GameState _previousGameState = default;
	
	public void UpdateGameState(GameState newGameState)
	{
		if (newGameState == CurrentGameState)
			return;

		_previousGameState = _currentGameState;
		_currentGameState = newGameState;
	}

	public void ResetToPreviousGameState()
	{
		if (_previousGameState == _currentGameState)
			return;
		
		// Swap the values via tuple deconstruction
		// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
		(_previousGameState, _currentGameState) = (_currentGameState, _previousGameState);
	}
}
