using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Cache level information
public class LevelManager
{
	private static LevelManager sharedInstance = null;
	public static LevelManager Instance
	{
		get
		{
			if (sharedInstance == null)
			{
				sharedInstance = new LevelManager();
			}
			return sharedInstance;
		}
	}

	private List<Level> levelCache;
	private Level currentLevel;

	private readonly int minLevelID = 0;
	private int maxLevelID;

	// Load all levels
	public void PreLoadLevels(string levelsPath)
    {
		levelCache = new List<Level>();
		int id = minLevelID;
		Level data;
		do
		{
			data = Resources.Load<Level>($"{levelsPath}/Level" + id);
			if (data != null)
			{
				levelCache.Add(data);
			}
			id++;
		} while (data != null);

		maxLevelID = levelCache.Count;
	}

	public Level GetLevel(int levelID)
    {
		if (levelID < minLevelID || levelID > maxLevelID)
        {
			Debug.LogError($"Attempting to access an undefined level of ID {levelID}");
			return null;
        }

		return levelCache[levelID];
    }

	public void LoadLevel(int levelID)
    {
		var level = GetLevel(levelID);

		if (level != null)
        {
			Debug.Log("Current level");

			var param = new Parameters();
			param.PutExtra("GameState", (int)GameState.PlayLevel);
			EventBroadcaster.Instance.PostEvent(EventNames.Starchaser.ON_GAME_STATE_SWITCH, param);

			// TODO: Entrance Scene Transition
			LoadManager.Instance.LoadScene(level.LevelScene);
		}
	}

	public int LevelCount { get => levelCache.Count; }
}
