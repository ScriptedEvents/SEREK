using System;
using Exiled.API.Features;
using SER.MethodSystem;

namespace SEREK;

public class Plugin : Plugin<Config>
{
    public override string Name => "SEREK";
    public override string Author => "Elektryk_Andrzej";
    public override Version Version => new(1, 0, 0);
    
    public override void OnEnabled()
    {
        try
        {
            MethodIndex.AddAllDefinedMethodsInAssembly();
            Log.Info("Scripted Events Reloaded was detected, methods have been loaded.");
        }
        catch (Exception e)
        {
            Log.Error($"Adding methods to SER has failed. Is SER installed? Do you have the latest version?\n{e}");
        }
    }
}
