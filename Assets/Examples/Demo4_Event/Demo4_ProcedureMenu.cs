using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
public class Demo4_ProcedureMenu : ProcedureBase
{
	protected override void OnEnter(ProcedureOwner procedureOwner)
	{
		base.OnEnter(procedureOwner);

		EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
		// 加载框架UI组件
		UIComponent UI
			= UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();

		Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

		// 加载UI
		UI.OpenUIForm("Assets/Examples/Demo3_UI/UI_Menu.prefab", "DefaultGroup",this);
	}

	private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
		OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;

		//判断userData是否为自己
		if (ne.UserData != this)
        {
			return;
        }

		Log.Info("你成功召唤了 UI_Menu(这是一个回调函数信息)");
    }
}