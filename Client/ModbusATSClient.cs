using System;
using System.Net;
using FluentModbus;

public class ModbusATSClient : IDisposable
{
    private readonly ModbusTcpClient _modbusClient;
    private readonly IPEndPoint _endpoint;

    public ModbusATSClient(string ipAddress, int port = 502)
    {
        _endpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        _modbusClient = new ModbusTcpClient();
    }

    public void Connect()
    {
        _modbusClient.Connect(_endpoint, ModbusEndianness.BigEndian);
    }

    public void Disconnect()
    {
        _modbusClient.Disconnect();
    }

    private int GetBaudRate(ModbusBaudRate baudRate)
    {
        return baudRate switch
        {
            ModbusBaudRate.Bauds_4800 => 4800,
            ModbusBaudRate.Bauds_9600 => 9600,
            ModbusBaudRate.Bauds_19200 => 19200,
            ModbusBaudRate.Bauds_38400 => 38400,
            _ => throw new ArgumentOutOfRangeException(nameof(baudRate), baudRate, null)
        };
    }

    private string GetVersion(int major, int minor)
    {
        return $"{major}.{minor}";
    }

    public void SetControlMode(Control control)
    {
        if (!_modbusClient.IsConnected)
        {
            throw new InvalidOperationException("Modbus client is not connected.");
        }

        _modbusClient.WriteSingleRegister(1, 32, (ushort)control);
    }

    public void SetOperatingMode(OperatingMode operatingMode)
    {
        if (!_modbusClient.IsConnected)
        {
            throw new InvalidOperationException("Modbus client is not connected.");
        }

        _modbusClient.WriteSingleRegister(1, 33, (ushort)operatingMode);
    }

    public AutomaticTransferSwitch ReadATSData()
    {
        if (!_modbusClient.IsConnected)
        {
            throw new InvalidOperationException("Modbus client is not connected.");
        }

        var inputRegisters1             = _modbusClient.ReadInputRegisters<ushort>(1, 1, 15).ToArray();
        var holdingRegisters1           = _modbusClient.ReadHoldingRegisters<ushort>(1, 16, 4).ToArray();
        var inputRegisters2             = _modbusClient.ReadInputRegisters<ushort>(1, 20, 6).ToArray();
        var softwareVersionRegister     = _modbusClient.ReadInputRegisters(1, 26, 1).ToArray();
        var inputRegisters4             = _modbusClient.ReadInputRegisters<ushort>(1, 27, 4).ToArray();
        var holdingRegisters2           = _modbusClient.ReadHoldingRegisters<ushort>(1, 33, 1).ToArray();

        var status = new AutomaticTransferSwitch
        {
            Switch1Status                   = (SwitchStatus)inputRegisters1[0],
            Switch2Status                   = (SwitchStatus)inputRegisters1[1],
            Line1Phase1Voltage              = inputRegisters1[2],
            Line1Phase2Voltage              = inputRegisters1[3],
            Line1Phase3Voltage              = inputRegisters1[4],
            Line2Phase1Voltage              = inputRegisters1[5],
            Line2Phase2Voltage              = inputRegisters1[6],
            Line2Phase3Voltage              = inputRegisters1[7],
            Line1Status                     = (LineStatus)inputRegisters1[8],
            Line2Status                     = (LineStatus)inputRegisters1[9],
            RatedVoltage                    = (RatedVoltage)inputRegisters1[10],
            UndervoltageThresholdPercent    = inputRegisters1[11],
            OvervoltageThresholdPercent     = inputRegisters1[12],
            TransferDelaySeconds            = inputRegisters1[13],
            ReturnDelaySeconds              = inputRegisters1[14],

            ModbusAddress                   = holdingRegisters1[0],
            ModbusBaudRate                  = GetBaudRate((ModbusBaudRate)holdingRegisters1[1]),
            ModbusParityCheck               = (ModbusParity)holdingRegisters1[2],
            ModbusStopBits                  = (ModbusStopBits)holdingRegisters1[3],

            DeviceWorkingMode               = (DeviceWorkingMode)inputRegisters2[0],
            LinePriority                    = (LinePriority)inputRegisters2[1],
            EmergencyOffStatus              = (EmergencyOffStatus)inputRegisters2[2],
            OperationCounter                = inputRegisters2[3],
            PresentAlarm                    = (Alarm)inputRegisters2[4],
            LastAlarm                       = (Alarm)inputRegisters2[5],

            SoftwareVersion                 = GetVersion(softwareVersionRegister[0], softwareVersionRegister[1]),

            Phases                          = (Phases)inputRegisters4[0],
            RatedFrequency                  = (RatedFrequency)inputRegisters4[1],
            GeneratorStopDelaySeconds       = inputRegisters4[2],
            GeneratorUsage                  = (GeneratorUsage)inputRegisters4[3],

            OperatingMode                   = (OperatingMode)holdingRegisters2[0]
        };

        return status;
    }

    public void Dispose()
    {
        _modbusClient.Dispose();
    }
} 
