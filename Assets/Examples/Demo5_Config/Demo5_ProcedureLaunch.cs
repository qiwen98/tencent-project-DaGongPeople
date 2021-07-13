using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using Demo5;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo5_ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 获取框架事件组件
        EventComponent Event = GameEntry.GetComponent<EventComponent>();
        // 获取框架数据表组件
        DataTableComponent dataTableComponent = GameEntry.GetComponent<DataTableComponent>();
        // 订阅加载成功事件
        Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        // 加载配置表
        IDataTable<DRHero> dataTable = dataTableComponent.CreateDataTable<DRHero>();
        DataTableBase dataTableBase = dataTable as DataTableBase;
        dataTableBase.ReadData("Assets/Examples/Demo5_Config/Hero.txt");
    }


    private void OnLoadDataTableFailure(object sender, GameEventArgs e)
    {
        Log.Debug("失败");
    }

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        Log.Debug("加载成功!");
        DataTableComponent dataTableComponent = GameEntry.GetComponent<DataTableComponent>();
        IDataTable<DRHero> dataTable = dataTableComponent.GetDataTable<DRHero>();

        //获得所有的行，并转化为数组（不转换带表格开头带#的）
        DRHero[] allData = dataTable.GetAllDataRows();
        Log.Debug("allData行数 : " + allData.Length);

        //获取的第x行的数据
        DRHero first = dataTable.GetDataRow(1);
        if (first != null)
        {
            Log.Debug(first.Id + "    " + first.Name + "    " + first.Atk);
        }

        //获取所有满足条件的行
        DRHero[] usefulRows = dataTable.GetDataRows((x) => { return x.Id > 0; });
        foreach (var v in usefulRows)
        {
            Log.Debug("usefulRows :" + v);
        }

        //获取第一次满足条件的行 返回它
        DRHero usefulRow = dataTable.GetDataRow((x) => { return x.Name == "mutou"; });
        Log.Debug("usefulRow:" + usefulRow);
    }
}