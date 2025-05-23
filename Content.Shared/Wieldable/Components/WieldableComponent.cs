using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.Wieldable.Components;

/// <summary>
///     Used for objects that can be wielded in two or more hands,
/// </summary>
[RegisterComponent, NetworkedComponent, Access(typeof(WieldableSystem)), AutoGenerateComponentState]
public sealed partial class WieldableComponent : Component
{
    [DataField("wieldSound")]
    public SoundSpecifier? WieldSound = new SoundPathSpecifier("/Audio/Effects/thudswoosh.ogg");

    [DataField("unwieldSound")]
    public SoundSpecifier? UnwieldSound;

    /// <summary>
    ///     Number of free hands required (excluding the item itself) required
    ///     to wield it
    /// </summary>
    [DataField("freeHandsRequired")]
    public int FreeHandsRequired = 1;

    [AutoNetworkedField, DataField("wielded")]
    public bool Wielded = false;

    /// <summary>
    ///     Whether using the item inhand while wielding causes the item to unwield.
    ///     Unwielding can conflict with other inhand actions. 
    /// </summary>
    [DataField]
    public bool UnwieldOnUse = true;

    [DataField("wieldedInhandPrefix")]
    public string? WieldedInhandPrefix = "wielded";

    public string? OldInhandPrefix = null;
    // WD EDIT START
    /// <summary>
    /// Requires item to be alt-used in hand (alt-Z / alt-click in active hand) to be wielded.
    /// </summary>
    [DataField]
    public bool AltUseInHand = false;

    public EntityUid? User = null;

    /// <summary>
    /// Automatically attempts to wield the item upon being picked or switched to (while held)
    /// </summary>
    [DataField]
    public bool AutoWield = true;
    // WD EDIT END
}

[Serializable, NetSerializable]
public enum WieldableVisuals : byte
{
    Wielded
}
