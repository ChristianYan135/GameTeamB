using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour
{
    public GameObject player;
    public GameObject bar;
    PlayerMove playerMove;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
