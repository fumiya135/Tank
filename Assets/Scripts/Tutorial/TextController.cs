using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] public GameObject Event1;
    [SerializeField] public GameObject Event2;
    [SerializeField] public GameObject Event3;
    string[] sentences_1; // 文章を格納する
    string[] sentences_2;
    string[] sentences_3;
    string[] sentences_4;
    [SerializeField] Text uiText;   // uiTextへの参照
    [SerializeField] public GameObject nextButton;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間

    private string[] currentSentences;
    private int state = 0;
    private int currentSentenceNum = 0; //現在表示している文章番号
    private string currentString = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;       // 表示中の文字数

    private bool eventActive = false;
    public bool eventfinished = false;
    public bool finished = false;

    void Start()
    {
        sentences_1 = new string[]{
            "皆さんこんにちは",
            "ここはタンクゲームのチュートリアルになるよ",
            "このゲームは敵を倒して得られた経験値から、どんどん強化をしてタンクを強くしていくゲームだよ",
            "A or Dキーで旋回、W or Sキーで前進後進できるよ",
            "マークの位置までタンクを動かしてみよう",
        };
        sentences_2 = new string[]{
            "OK!！",
            "次は敵を倒してみよう",
            "マウスカーソルを敵に合わせて、左クリックで攻撃しよう",
        };
        sentences_3 = new string[] {
            "ナイス！",
            "複数の敵にはチャージショットが有効だよ",
            "左クリック長押しでチャージショットを撃ってみよう",
        };
        sentences_4 = new string[] {
            "いいね！",
            "チュートリアルはこれで終わりだよ",
            "セーフハウスでタンクを強化して冒険にでよう",
        };
        state = 0;
        currentSentences = sentences_1;
        SetNextSentence();
    }


    public void TextUpdate(bool _IsPush)
    {
        if (finished == false)
        {
            // 文章の表示完了 / 未完了
            if (IsDisplayComplete())
            {
                //最後の文章ではない & ボタンが押された
                if (currentSentenceNum < currentSentences.Length && _IsPush)
                {
                    SetNextSentence();
                }

                else if (currentSentenceNum >= currentSentences.Length)
                {
                    // Eventを有効化
                    if (eventActive == false)
                    {
                        ActiveEvent();
                        eventActive = true;

                        nextButton.SetActive(false);

                        // playerを止める
                        GameObject player = GameObject.Find("Tank");
                        player.GetComponent<PlayerController>().enabled = true;
                        player.GetComponent<ThirdPersonControler>().enabled = true;
                    }

                    // Event終了時
                    if (eventfinished == true)
                    {
                        ChangSentences();
                        currentSentenceNum = 0;

                        eventActive = false;

                        TextUpdate(true);
                        nextButton.SetActive(true);

                        // playerを動かせる
                        GameObject player = GameObject.Find("Tank");
                        player.GetComponent<PlayerController>().enabled = false;
                        player.GetComponent<ThirdPersonControler>().enabled = false;
                    }
                }
            }
            else
            {
                if (_IsPush)
                {
                    timeUntilDisplay = 0; //※1
                }
            }

            //表示される文字数を計算
            int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentString.Length);

            //表示される文字数が表示している文字数と違う
            if (displayCharCount != lastUpdateCharCount)
            {
                uiText.text = currentString.Substring(0, displayCharCount);
                //表示している文字数の更新
                lastUpdateCharCount = displayCharCount;
            }
        }
    }

    // 次の文章をセットする
    void SetNextSentence()
    {
        currentString = currentSentences[currentSentenceNum];
        timeUntilDisplay = currentString.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        currentSentenceNum++;
        lastUpdateCharCount = 0;
    }

    void ChangSentences()
    {
        state++;
        switch (state)
        {
            case 1:
                currentSentences = sentences_2;
                break;
            case 2:
                currentSentences = sentences_3;
                break;
            case 3:
                currentSentences = sentences_4;
                break;
            case 4:
                break;
        }
    }

    void ActiveEvent()
    {
        switch (state)
        {
            case 0:
                Event1.SetActive(true);
                break;
            case 1:
                Event2.SetActive(true);
                break;
            case 2:
                Event3.SetActive(true);
                break;
            case 3:
                finished = true;
                TutorialFinish();
                break;
        }
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }

    public void Eventfinished(bool eventfinish)
    {
        eventfinished = eventfinish;
    }

    void TutorialFinish()
    {
        nextButton.SetActive(false);

        TutorialManager script = GameObject.Find("TutorialSystem").GetComponent<TutorialManager>();
        script.TutorialFinish();
        this.gameObject.GetComponent<TextController>().enabled = false;
    }
}