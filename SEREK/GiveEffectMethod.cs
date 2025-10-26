using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using SER.ArgumentSystem.Arguments;
using SER.ArgumentSystem.BaseArguments;
using SER.Helpers.Extensions;
using SER.MethodSystem.BaseMethods;

namespace SEREK;

public class GiveEffectMethod : SynchronousMethod
{
    public override string Description => "Gives an effect to players.";

    public override Argument[] ExpectedArguments { get; } =
    [
        new PlayersArgument("players"),
        new EnumArgument<EffectType>("effect"),
        new IntArgument("intensity", 0, 255)
        {
            DefaultValue = 1,
        },
        new DurationArgument("duration")
        {
            DefaultValue = TimeSpan.Zero,
            Description = "Do not provide this argument for a permament effect."
        },
    ];
    
    public override void Execute()
    {
        var players = Args.GetPlayers("players");
        var effect = Args.GetEnum<EffectType>("effect");
        var intensity = Args.GetInt("intensity");
        var duration = Args.GetDuration("duration");
            
        foreach (Player player in players)
        {
            Effect eff = new(effect, duration.ToFloatSeconds(), (byte)intensity);
            player.SyncEffect(eff);
        }
    }
}