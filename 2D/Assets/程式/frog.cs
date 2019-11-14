using UnityEngine;
using UnityEngine.UI;

public class frog : MonoBehaviour
{
    #region 欄位/屬性
    // 定義列舉
    // 修飾詞 列舉 列舉名稱 { 列舉內容, .... }
    public enum state
    {
        // 一般、尚未完成、完成
        star, notComplete, complete
    }
    // 使用列舉
    // 修飾詞 類型 名稱
    public state _state;


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
    [Header("UI")]
    public GameObject objcan;
    public Text textSay;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            Say();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Sayout();
    }

    /// <summary>
    /// 對話
    /// </summary>
    void Say()
    {
        objcan.SetActive(true);
        textSay.text = star;
        switch (_state)
        {
            case star:
                print("玩家輸入的是黑色");
                break;
            case notcomplete:
                print("玩家輸入的是紅色");
                break;
        }
    }

    /// <summary>
    /// 離開對話
    /// </summary>
    void Sayout()
    {
        objcan.SetActive(false);
    }
}
