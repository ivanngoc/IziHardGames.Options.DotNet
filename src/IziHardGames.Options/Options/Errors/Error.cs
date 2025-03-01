namespace IziHardGames.Options.Errors
{
    public struct Error
    {
        /// <summary>
        /// Serialized data
        /// </summary>
        public byte[]? Data { get; }
        public string Message { get; }

        public Error(byte[]? data, string message)
        {
            Data = data;
            Message = message;
        }
    }
}
