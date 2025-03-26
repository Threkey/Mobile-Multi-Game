using UnityEngine;
using Photon.Pun;
using TMPro;

public class test : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI textProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        textProgress.text = string.Format("{0:F0}%", PhotonNetwork.LevelLoadingProgress * 100);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LoadLevel("TestLobby");
    }
}
