using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    [Header ("任務對話")]
    public string star = "嘿，幫我找5顆鑽石嗎?";
    public string not_complete = "你還沒找到5顆鑽石，等你找到再來找我吧";
    public string complete = "謝了老兄";
    [Header ("對話速度")]
    public float talkspeed = 1f;
    [Header("任務")]
    public bool mission_complete = false;
    public int count_player = 0;
    public int finish = 5;

	// Use this for initialization
	void Start ()
    {
        Debug.Log(star);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
