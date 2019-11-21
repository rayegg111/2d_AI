using UnityEngine;
using System.Collections;  //引用 系統.集合 API

public class LearnArrayFor : MonoBehaviour
{
    public string say = "這是練習測試";
    // { 陣列資料 }
    public int[] score = { 100, 90, 80, 70, 60, 50 };
    //類型 [] 陣列 = new 類型 [ 數量 ]
    public float[] value = new float[7];

	void Start ()
    {
        //陣列編號從0開始
        print(say[3]);
        print("字串長度：" + say.Length);
        
        //存放陣列
        score[2] = 50;
        //取的陣列
        print(score[2]);

        for (int i = 0; i < 10; i++)
        {
            print("數字：" + i);
        }

        for (int i = 0; i < score.Length; i++)
        {
            print("分數：" + score[i]);
        }

        //StartCoroutine(Test());  //啟動協同程式
        StartCoroutine(Printer());
	}
    
    //協同程序
    private IEnumerator Test()
    {
        print("開始：");
        yield return new WaitForSeconds(2);
        print("兩秒測試");
    }

    private IEnumerator Printer()
    {
        for (int i = 0; i < say.Length; i++)
        {
            print(say[i]);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
