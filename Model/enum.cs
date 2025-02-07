using System;
using System.ComponentModel;

public enum SwitchStatus
{
    Open = 0,
    Closed = 1
}

public enum LineStatus
{
    VoltageOK = 0,
    NoVoltage = 1,
    Undervoltage = 2,
    Overvoltage = 3,
    PhaseMissing = 4
}

/// <summary>
/// Specifies the rated voltage values.
/// </summary>
public enum RatedVoltage
{
    /// <summary>
    /// 220/380V
    /// </summary>
    [Description("220/380V")]
    V_220_380 = 0,

    /// <summary>
    /// 230/400V
    /// </summary>
    [Description("230/400V")]
    V_230_400 = 1,

    /// <summary>
    /// 240/415V
    /// </summary>
    [Description("240/415V")]
    V_240_415 = 2
}

public enum ModbusBaudRate
{
    Bauds_4800 = 0,
    Bauds_9600 = 1,
    Bauds_19200 = 2,
    Bauds_38400 = 3
}

public enum ModbusParity
{
    NoParity = 0,
    Odd = 1,
    Even = 2
}

public enum ModbusStopBits
{
    One = 0,
    Two = 1
}

public enum DeviceWorkingMode
{
    Manual = 0,
    EmergencyOff = 1,
    LocalTest = 2,
    RemoteTest = 3,
    Auto = 4
}

public enum LinePriority
{
    Line1 = 0,
    NoLinePriority = 1,
    ManualBackSwitching = 2
}

public enum EmergencyOffStatus
{
    NoEmergencyOff = 0,
    EmergencyOff = 1
}

public enum Phases
{
    ThreePhaseWithNeutral = 0,
    ThreePhaseWithoutNeutral = 1,
    SinglePhase = 2
}

public enum RatedFrequency
{
    FiftyHertz = 0,
    SixtyHerts = 1
}

public enum GeneratorUsage
{
    NoGenerator = 0,
    GeneratorInUse = 1
}

public enum Control
{
    RemoteControlToI = 1,
    RemoteControlToO = 2,
    RemoteControlToII = 3,
    RemoteTestFunction = 4
}

public enum OperatingMode
{
    LocalMonitoringMode = 0,
    RemoteControlMode = 1
}

// Enum for alarm states
public enum Alarm
{
    NoAlarms = 0,
    SwitchITransferFail = 1,
    SwitchIITransferFail = 2,
    BothIandIIOn = 3,
    SwitchITransferFailInEmergencyOff = 4,
    SwitchIITransferFailInEmergencyOff = 5
}
