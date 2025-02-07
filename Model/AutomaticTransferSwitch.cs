public class AutomaticTransferSwitch
{
    // Switch statuses
    public SwitchStatus Switch1Status { get; set; }
    public SwitchStatus Switch2Status { get; set; }

    // Voltage readings (now using ushort for voltage values)
    public int Line1Phase1Voltage { get; set; }
    public int Line1Phase2Voltage { get; set; }
    public int Line1Phase3Voltage { get; set; }
    public int Line2Phase1Voltage { get; set; }
    public int Line2Phase2Voltage { get; set; }
    public int Line2Phase3Voltage { get; set; }

    // Line status
    public LineStatus Line1Status { get; set; }
    public LineStatus Line2Status { get; set; }

    // Rated voltage
    public RatedVoltage RatedVoltage { get; set; }

    // Voltage thresholds
    public int UndervoltageThresholdPercent { get; set; }
    public int OvervoltageThresholdPercent { get; set; }

    // Delays
    public int TransferDelaySeconds { get; set; }
    public int ReturnDelaySeconds { get; set; }

    // Modbus communication settings
    public int ModbusAddress { get; set; }
    public int ModbusBaudRate { get; set; }
    public ModbusParity ModbusParityCheck { get; set; }
    public ModbusStopBits ModbusStopBits { get; set; }

    // Device working mode
    public DeviceWorkingMode DeviceWorkingMode { get; set; }

    // Line priority and operation mode
    public LinePriority LinePriority { get; set; }
    public EmergencyOffStatus EmergencyOffStatus { get; set; }

    // Operational counters and alarms
    public int OperationCounter { get; set; }
    public Alarm PresentAlarm { get; set; }
    public Alarm LastAlarm { get; set; }

    // Software version
    public string SoftwareVersion { get; set; }

    // Phases and frequency
    public Phases Phases { get; set; }
    public RatedFrequency RatedFrequency { get; set; }

    // Generator related settings
    public int GeneratorStopDelaySeconds { get; set; }
    public GeneratorUsage GeneratorUsage { get; set; }
 
    // Remote control settings
    public OperatingMode OperatingMode { get; set; }

    public AutomaticTransferSwitch()
    {
        // Default initialization if needed
        SoftwareVersion = string.Empty;
    }
}