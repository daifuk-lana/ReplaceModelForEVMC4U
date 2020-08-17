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
        ModelAnims = new Animator[Models.Length];
        ModelTranses = new Transform[Models.Length];
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
        for (int i = 0; i < Models.Length; i++)
        {
            ModelAnims[i] = Models[i].GetComponent<Animator>();
            ModelTranses[i] = Models[i].GetComponent<Transform>();
            if (i != 0)
            {
                Models[i].SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < InputKey.Length; i++)
        {
            if (Input.GetKey(InputKey[i]))
            {
                ModelInput(i);
            }
        }
    }
    void ModelInput(int a)
    {
        for (int i = 0; i < InputKey.Length; i++)
        {
            if(i == a)
            {
                Models[a].SetActive(true);
                ReplaceModel.Model = Models[a];
                ReplaceModel.RootRotationTransform = ModelTranses[a];
                ReplaceModel.RootPositionTransform = ModelTranses[a];
                if(TeleportManager != null)
                {
                    MoveModel.model = ModelAnims[a];
                }
                for (int j = 0; j < VCams.Length; j++)
                {
                    VCams[j].LookAt = ModelTransesHead[a];
                }
            }
            else
            Models[i].SetActive(false);
        }
    }
}