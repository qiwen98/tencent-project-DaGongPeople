using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 英雄逻辑处理
/// </summary>
public class Demo7_CubeLogic : EntityLogic
{
    protected Demo7_CubeLogic()
    {
        
    }

    protected override void OnShow(object userData)
    {
        Animation anim = this.GetComponent<Animation>();
        anim.Play("AnimateCube");

        base.OnShow(userData);

        Log.Debug("显示英雄实体.");
    }
}