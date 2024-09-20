namespace AutoServiceGame.Entities.AutoServices;

public class AutoService
{
    private AutoServiceModel _autoServiceModel;
    private AutoServiceView _autoServiceView;

    public AutoService(AutoServiceModel autoServiceModel, AutoServiceView autoServiceView)
    {
        _autoServiceModel = autoServiceModel;
        _autoServiceView = autoServiceView;
    }

    public void ShowStartWindow()
    {
        _autoServiceView.ShowStartWindow();
    }

    public void DisplayMainMenu()
    {
        _autoServiceView.DisplayMainMenu();
    }

    public void DisplayBalance()
    {
        _autoServiceView.DisplayBalance(_autoServiceModel.Balance);
    }

    public void DisplayInventory()
    {
        _autoServiceView.DisplayInventory(_autoServiceModel.GetAllParts());
    }
}