using TaiwuModdingLib.Core.Plugin;
using UnityEngine;

namespace TestMod
{
    [PluginConfig("TestMod", "剑圣(skyswordkill)", "1.0.0")]
    public class ModMain : TaiwuRemakePlugin
    {
        public ModMono ModMono;
        
        public override void Initialize()
        {
            ABResourceManager.Init(ModIdStr);
            ModMono = new GameObject("TestMod").AddComponent<ModMono>();
        }

        public override void Dispose()
        {
            ABResourceManager.UnInit();
            if (ModMono != null)
            {
                GameObject.Destroy(ModMono.gameObject);
            }
        }
    }
}