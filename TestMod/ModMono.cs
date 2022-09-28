using System;
using UnityEngine;

namespace TestMod
{
    public class ModMono : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F2))
            {
                ABResourceManager.Instantiate("UIPrefab/UI_ABC.prefab").AddComponent<UI_ABC>();
            }
        }
    }
}