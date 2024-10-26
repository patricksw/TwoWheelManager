namespace P5Tech.TwoWheelManager.Domain
{
    public class Document
    {
        public string Id { get; init; }
        public byte[] Content { get; private set; }

        public void SetContent(byte[] content) => Content = content;
    }
}