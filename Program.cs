class Program
{
    static void Main()
    {
        using var atsClient = new ModbusATSClient("192.168.1.28");
        atsClient.Connect();
        var atsData = atsClient.ReadATSData();

        // atsClient.SetOperatingMode(OperatingMode.RemoteControlMode);

        // atsClient.SetControlMode(Control.RemoteControlToII);

        Console.WriteLine("ATS Data:");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("| Property                       | Value                    |");
        Console.WriteLine("------------------------------------------------------------");

        foreach (var property in atsData.GetType().GetProperties())
        {
            var value = property.GetValue(atsData, null);
            Console.WriteLine($"| {property.Name, -30} | {value, -24} |");
        }

        Console.WriteLine("--------------------------------------------------");

        //atsClient.SetOperatingMode(OperatingMode.LocalMonitoringMode);
    }
}
