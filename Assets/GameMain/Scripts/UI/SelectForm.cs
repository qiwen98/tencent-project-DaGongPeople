using UnityEngine;
using UnityGameFramework.Runtime;

namespace DaGong
{
    public class SelectForm : UGuiForm
    {
        [SerializeField]
        private ProcedureSelect m_ProcedureSelect = null;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_ProcedureSelect = (ProcedureSelect)userData;
            if (m_ProcedureSelect == null)
            {
                Log.Warning("m_ProcedureSelect is invalid when open MenuForm.");
                return;
            }
        }
        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureSelect = null;

            base.OnClose(isShutdown, userData);
        }
    }
}