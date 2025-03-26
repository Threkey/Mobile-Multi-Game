using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MatchMakingTest : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TextMeshProUGUI textPlayerCount;
    RoomOptions roomOptions = new RoomOptions();
    [SerializeField]
    GameObject canvasTest;

    bool isMatched = false;
    void Start()
    {
        isMatched = false;
        roomOptions.MaxPlayers = 2;
        DefaultPool pool = PhotonNetwork.PrefabPool as DefaultPool;
        pool.ResourceCache.Clear();
        pool.ResourceCache.Add("CanvasTest", canvasTest);
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            textPlayerCount.text = string.Format("{0:D} / {1:D}", PhotonNetwork.CurrentRoom.PlayerCount, PhotonNetwork.CurrentRoom.MaxPlayers);
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers && !isMatched)
            {
                isMatched = true;
                Instantiate(canvasTest, Vector3.zero, Quaternion.identity);
            }
        }

        else
            textPlayerCount.text = "not joined";



    }

    public void JoinRoom()
    {
        if (PhotonNetwork.CurrentRoom == null)
            PhotonNetwork.JoinRandomOrCreateRoom(null, 2, MatchmakingMode.FillRoom, null, null, null, roomOptions, null);
        else
            PhotonNetwork.LeaveRoom();
    }

    override public void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");
    }
}
