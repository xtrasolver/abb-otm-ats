public class AutomaticTransferSwitch
{
    // Switch statuses
    public SwitchStatus Switch1Status { get; internal set; }
    public SwitchStatus Switch2Status { get; internal set; }

    // Voltage readings (now using ushort for voltage values)
    public int Line1Phase1Voltage { get; internal set; }
    public int Line1Phase2Voltage { get; internal set; }
    public int Line1Phase3Voltage { get; internal set; }
    public int Line2Phase1Voltage { get; internal set; }
    public int Line2Phase2Voltage { get; internal set; }
    public int Line2Phase3Voltage { get; internal set; }

    // Line status
    public LineStatus Line1Status { get; internal set; }
    public LineStatus Line2Status { get; internal set; }

    // Rated voltage
    public RatedVoltage RatedVoltage { get; internal set; }

    // Voltage thresholds
    public int UndervoltageThresholdPercent { get; internal set; }
    public int OvervoltageThresholdPercent { get; internal set; }

    // Delays
    public int TransferDelaySeconds { get; internal set; }
    public int ReturnDelaySeconds { get; internal set; }

    // Modbus communication settings
    public int ModbusAddress { get; internal set; }
    public int ModbusBaudRate { get; internal set; }
    public ModbusParity ModbusParityCheck { get; internal set; }
    public ModbusStopBits ModbusStopBits { get; internal set; }

    // Device working mode
    public DeviceWorkingMode DeviceWorkingMode { get; internal set; }

    // Line priority and operation mode
    public LinePriority LinePriority { get; internal set; }
    public EmergencyOffStatus EmergencyOffStatus { get; internal set; }

    // Operational counters and alarms
    public int OperationCounter { get; internal set; }
    public Alarm PresentAlarm { get; internal set; }
    public Alarm LastAlarm { get; internal set; }

    // Software version
    public string SoftwareVersion { get; internal set; }

    // Phases and frequency
    public Phases Phases { get; internal set; }
    public RatedFrequency RatedFrequency { get; internal set; }

    // Generator related settings
    public int GeneratorStopDelaySeconds { get; internal set; }
    public GeneratorUsage GeneratorUsage { get; internal set; }
    
    // Remote control settings
    public OperatingMode OperatingMode { get; internal set; }

    public AutomaticTransferSwitch()
    {
        // Default initialization if needed
        SoftwareVersion = string.Empty;
    }
}
