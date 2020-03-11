using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour
{
    public GameObject player;
    public GameObject bar;
    PlayerMove playerMove;
    float timeMax;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        timeMax = playerMove.dashTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        bar.transform.localScale = new Vector3(playerMove.dashTimer / timeMax, bar.transform.localScale.y);
    }
}
