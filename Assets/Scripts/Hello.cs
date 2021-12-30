using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Assets.Scripts.Utils;

public class Hello : MonoBehaviour
{
    public Scene _sence;
    public int num;
    public Button btn;
    private Texture myTexture;

    private Facebook fb;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
        var scene = SceneManager.GetActiveScene();
        Debug.Log("This Scene Name is: " + scene.name);
        var scene2 = SceneManager.GetSceneByPath("Assets/Scenes/SampleScene.unity");
        Debug.Log("This Path Scene Name is: " + scene2.name);
        
        if (_sence == null)
        {
            _sence = scene2;
        }
        btn.GetComponentInChildren<Text>().text = "hello";

        StartCoroutine(GetText());
        StartCoroutine(GetTexture());
        FC.Hello();
        Facebook.GetInfo(123123);

        fb = new Facebook();
        fb.Hello();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse(0) click");
            Debug.Log("my scene name: " + _sence.name);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("mouse(1) click");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("key(m) press");
        }
    }

    public void Click()
    {
        Debug.Log("Func Click Call!");

    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.56.101/mm/api.php");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError 
            || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            //byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://192.168.56.1/mm/i/1/402/12/i6402b.png");
        yield return www.SendWebRequest();

        GetComponentInChildren<RawImage>().texture = DownloadHandlerTexture.GetContent(www);
        myTexture = GetComponentInChildren<RawImage>().texture;
        Debug.Log("texture width: " + myTexture.width + ", height: "+myTexture.height);

    }
}
