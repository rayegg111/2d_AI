using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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


    [Header("任務對話")]
    public string star = "能拿5顆鑽石給我嗎";
    public string notcomplete = "還沒找到5顆鑽石，等全找到再來找我吧";
    public string complete = "謝了老兄";
    [Header("對話速度")]
    public float talkspeed = 0.1f;
    [Header("任務")]
    public bool mission_complete = false;
    public int count_player = 0;
    public int finish = 5;
    [Header("UI")]
    public GameObject objcan;
    public Text textSay;
    [Header("音效")]
    public AudioClip saysound;
    public float soundspeed = 0.5f;
    private AudioSource asu;
    #endregion


    private void Start()
    {
        asu = GetComponent<AudioSource>();
    }

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
        StopAllCoroutines();

        if (count_player >= finish) _state = state.complete;

        // 判斷式(狀態)
        switch (_state)
        {
            case state.star:
                StartCoroutine(ShowDialog(star));         // 開始對話
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(notcomplete));  // 未完成對話
                break;
            case state.complete:
                StartCoroutine(ShowDialog(complete));     // 完成對話
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)
        {
            textSay.text += say[i].ToString();
            asu.PlayOneShot(saysound, soundspeed);
            yield return new WaitForSeconds(talkspeed);
        }
    }

    /// <summary>
    /// 離開對話
    /// </summary>
    void Sayout()
    {
        StopAllCoroutines();
        objcan.SetActive(false);
    }

    /// <summary>
    /// 取得任務道具
    /// </summary>
    void playerget()
    {
        count_player++;
    }
}
