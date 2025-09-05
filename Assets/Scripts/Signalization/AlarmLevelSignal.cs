using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct AlarmLevelSignal
{
    public readonly float Volume;
    public AlarmLevelSignal(float volume) => Volume = volume;
}
