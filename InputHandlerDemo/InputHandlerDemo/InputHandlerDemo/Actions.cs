namespace InputHandlerDemo
{
    /// <summary>
    /// Actions that will be defined for the game are declared
    /// as constants so you don't have magic strings floating
    /// around and more importantly so you can use IntelliSense
    /// to access them in your code
    /// </summary>
    public static class Actions
    {
        public const string Jump = "Jump";
        public const string Exit = "Exist";
        public const string Up = "Up";
        public const string Pause = "Pause";
    }
}