namespace AutoService.Entities.AutoService;

public class AutoService
{
    private AutoServiceModel _autoServiceModel;
    private AutoServiceView _autoServiceView;

    public AutoService(AutoServiceModel autoServiceModel, AutoServiceView autoServiceView)
    {
        _autoServiceModel = autoServiceModel;
        _autoServiceView = autoServiceView;
    }
} 