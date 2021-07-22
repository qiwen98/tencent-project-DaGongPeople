
using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace DaGong
{
    public class ProcedureSelect : ProcedureBase
    {
        private bool m_Selected = false;
        private SelectForm m_SelectForm = null;

        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            m_Selected = false;
            GameEntry.UI.OpenUIForm(UIFormId.SelectForm, this);
        }
        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_SelectForm = (SelectForm)ne.UIForm.Logic;
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_Selected)
            {
                //procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main"));
                //procedureOwner.SetData<VarByte>("GameMode", (byte)GameMode.Survival);
                //ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }
    }
    

}