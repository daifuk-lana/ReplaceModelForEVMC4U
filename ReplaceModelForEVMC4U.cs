using Cinemachine;
using EVMC4U;
using UnityEngine;

public class ReplaceModelForEVMC4U : MonoBehaviour
{
    public GameObject ExternalReceiver;
    public GameObject TeleportManager;
    public GameObject[] Models = new GameObject[2];
    public Transform[] ModelTransesHead = new Transform[2];
    public CinemachineVirtualCamera[] VCams = new CinemachineVirtualCamera[2];
    public KeyCode[] InputKey = new KeyCode[2];

    Animator[] ModelAnims;
    Transform[] ModelTranses;
    ExternalReceiver ReplaceModel;
    TeleportManager MoveModel;
    void Start()
    {
        //モデル分Animator、Transform配列の大きさを宣言
        ModelAnims = new Animator[Models.Length];
        ModelTranses = new Transform[Models.Length];
        //ExternalReceiver、TeleportManagerの有無判定
        if (ExternalReceiver != null) {
            ReplaceModel = ExternalReceiver.GetComponent<ExternalReceiver>();
        }
        else {
            Debug.LogError("ReplaceModel is null.");
        }
        if (TeleportManager != null)
        {
            MoveModel = TeleportManager.GetComponent<TeleportManager>();
        }
        else
        {
            Debug.Log("MoveModel is null.");
        }
        //Model数分Animator、Transformに代入
        for (int i = 0; i < Models.Length; i++)
        {
            ModelAnims[i] = Models[i].GetComponent<Animator>();
            ModelTranses[i] = Models[i].GetComponent<Transform>();
            //初期状態のモデル以外を非表示
            if (i != 0)
            {
                Models[i].SetActive(false);
            }
        }
    }
    void Update()
    {
        //キー入力取得
        for (int i = 0; i < InputKey.Length; i++)
        {
            //指定したキー入力時モデル切り替えメソッドを呼ぶ
            if (Input.GetKey(InputKey[i]))
            {
                ModelInput(i);
            }
        }
    }
    //モデル切り替えメソッド
    void ModelInput(int a)
    {
        //設定した入力キー分処理
        for (int i = 0; i < InputKey.Length; i++)
        {
            //入力キーと一致した際の処理（モデル表示）
            if(i == a)
            {
                //切り替え先モデルの代入
                Models[a].SetActive(true);
                ReplaceModel.Model = Models[a];
                ReplaceModel.RootRotationTransform = ModelTranses[a];
                ReplaceModel.RootPositionTransform = ModelTranses[a];
                //TeleportManagerへの代入
                if(TeleportManager != null)
                {
                    MoveModel.model = ModelAnims[a];
                }
                //シネスイッチャー(VCam)への代入
                for (int j = 0; j < VCams.Length; j++)
                {
                    VCams[j].LookAt = ModelTransesHead[a];
                }
            }
            //入力キーとの不一致時の処理（モデル非表示）
            else
            Models[i].SetActive(false);
        }
    }
}