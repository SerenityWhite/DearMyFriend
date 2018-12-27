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

        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                string userName = Social.localUser.userName;
                string userID = Social.localUser.id;
                Debug.Log("Login Success");
            }
            else
            {
                Debug.Log("Login Fail");
            }
        });
    }
}
