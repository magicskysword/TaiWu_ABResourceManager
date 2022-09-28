using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestMod
{
    public class UI_ABC : MonoBehaviour
    {
        public Text TxtTitle;
        public Button BtnClose;
        
        public void Start()
        {
            TxtTitle = transform.Find("MainWindow/TxtTitle").GetComponent<Text>();
            BtnClose = transform.Find("MainWindow/BtnClose").GetComponent<Button>();

            TxtTitle.text = "Mod脚本加载成功！";
            BtnClose.onClick.AddListener(() => { Destroy(gameObject); });
        }
    }
}