using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameView gameView;
    private PlayerModel playerModel;
    private GameAPI gameAPI;

    void Start()
    {
        gameAPI = gameObject.AddComponent<GameAPI>();
        gameView.SetRegisterButonListener(OnRegisterButtonClicked);
        gameView.SetLoginButonListener(OnLoginButtonClicked);
        gameView.SetCollectButonListener(OnCollectButtonClicked);
    }

    public void OnRegisterButtonClicked()
    {
        string playerName = gameView.playerNameInput.text;
        StartCoroutine(gameAPI.RegisterPlayer(playerName, "1234"));         //예시 비밀번호
    }

    public void OnLoginButtonClicked()
    {
        string playerName = gameView.playerNameInput.text;
        StartCoroutine(LoginPlayerCoroutine(playerName, "1234"));          //예시 비밀번호
    }

    public void OnCollectButtonClicked()
    {
        if(playerModel != null)
        {
            Debug.Log($"Collecting resources for : {playerModel.playerName}");
            StartCoroutine(CollectCoroutine(playerModel.playerName));
        }
        else
        {
            Debug.LogError("Player model is null");
        }
    }

    private IEnumerator CollectCoroutine(string playerName)
    {
        yield return gameAPI.CollectResources(playerName, player =>
        {
            playerModel.metal = player.metal;      
            playerModel.crystal = player.crystal;
            playerModel.deuterium = player.deuterium;
            UpdateResourcesDisplay();
        });
    }

    private IEnumerator LoginPlayerCoroutine(string playerName, string password)
    {
        yield return gameAPI.LoginPlayer(playerName, password, player =>
        {
            playerModel = player;       //로그인 성공시 playerModel 업데이트
            UpdateResourcesDisplay();
        });
    }

    private void UpdateResourcesDisplay()
    {
        if(playerModel != null) //playerModel이 null이 아닐때만 UI 업데이트
        {
            gameView.SetPlayerName(playerModel.playerName);
            gameView.UpdateResources(playerModel.metal, playerModel.crystal, playerModel.deuterium);
        }
    }

}
