using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackOnClick : MonoBehaviour
{
    public Button BackBtn;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = BackBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick(){
        if (Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
        AudioManager.Get().PlaySound(AudioManager.SoundClipName.PanelClose);
    }
}
