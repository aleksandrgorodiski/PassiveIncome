using System;
using UnityEngine;

public class GameController : GameElement
{
    public event Action<UnitModel> ON_FINISHED_STUDY_GLOBAL;
    public event Action<UnitModel> ON_TRIED_TO_GO_STUDY_GLOBAL;
    public event Action<UnitModel> ON_GET_SALARY_GLOBAL;
    
    public SaveSystemController saveSystemController;
    public LoadedDataController loadedDataController;
    //public  


    private void Start()
    {
        app.view.CreateBuildingsView();
        saveSystemController.LoadData();
    }

    public void OnFinishedPregnantGlobal(UnitModel model)
    {
        app.controller.loadedDataController.AddDefaultUnit();
    }
    public void OnFinishedStudyGlobal(UnitModel model)
    {
        ON_FINISHED_STUDY_GLOBAL?.Invoke(model);
    }
    public void OnTriedToGoStudyGlobal(UnitModel model)
    {
        ON_TRIED_TO_GO_STUDY_GLOBAL?.Invoke(model);
    }
    public void OnGetSalaryGlobal(UnitModel model)
    {
        ON_GET_SALARY_GLOBAL?.Invoke(model);
        app.model.balanceModel.Cash = model.ProfConfig.professionSalary;
int vIn = 0;
ulong vOut = Convert.ToUInt64(vIn)
    }
}
