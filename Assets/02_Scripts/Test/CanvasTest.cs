using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;

public class CanvasTestddass : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textCount;
    float count = 5.99f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 5.99f;
        StartCoroutine(coCountdown());
    }

    void Update()
    {
        textCount.text = string.Format("{0:D1}", (int)count);
    }

    IEnumerator coCountdown()
    {
        while (true)
        {
            yield return null;
            count -= Time.deltaTime;

            if (count <= 0)
            {
                PhotonNetwork.LoadLevel("GamePlayScene");
            }
        }
    }
}
