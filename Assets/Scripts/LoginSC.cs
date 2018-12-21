using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LoginSC : MonoBehaviour
{
	void Start ()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
	}
	
	void Update ()
    {
		
	}
}
