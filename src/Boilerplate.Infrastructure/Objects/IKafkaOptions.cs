namespace Boilerplate.Api.Objects
{
    public class KafkaOptions
    {
        public List<Topics> Topics { get; init; }
    }

    public class Topics
    {
        public string Name { get; init; }
        public string Value { get; init; }
    }
}
