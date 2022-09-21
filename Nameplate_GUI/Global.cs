internal static class Global
{
    private static bool _serialOn = false;      //For programmer to manually turn serialCom ON/OFF to test UI without machine

    public static bool SerialOn
    {
        get { return _serialOn; }
    }
}