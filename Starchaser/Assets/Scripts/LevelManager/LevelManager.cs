using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//public struct LevelData
//{
//	bool IsUnlocked { get; }

//	public string Name { get; }

//	public enum Rank
//	{
//		None,
//		RankD,
//		RankC,
//		RankB,
//		RankA,
//		RankS
//	}

//	public Rank AchievedRank { get; }

//	Time AchievedTime { get; } // Store the most quickest time recorded

//	Time TimeRequiredForRankA { get; }

//	Time TimeRequiredForRankS { get; }
//	int AchievedScore { get; }
//}

//Cache level necessary information
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

	private bool hasLoadedLevels;

	private List<Level> levelCache = new List<Level>();

	public void PreLoadLevelInformation(string levelsPath)
    {
		// Load all levels
		int id = 0;
		LevelData data;
		do
		{
			data = Resources.Load<LevelData>($"{levelsPath}/Level" + id);
			if (data != null)
			{
				levelCache.Add(new Level(data));
			}
			id++;
		} while (data != null);
	}

	public void LoadLevel(int levelID)
    {
		if (levelID < 0 || levelID > levelCache.Count)
		{
			Debug.LogError("Attempting to access an undefined level of ID " + levelID);
			return;
		}
		LoadManager.Instance.LoadScene("Level" + levelID);
    }

	public Level GetLevel(int levelID)
    {
		if (levelID < 0 || levelID > levelCache.Count)
        {
			Debug.LogError("Attempting to access an undefined level of ID " + levelID);
			return null;
        }

		return levelCache[levelID];
    }

	public int LevelCount
    { 
		get
        {
			return levelCache.Count;
        }
	}
}
