using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "localhost:9002" };

Action<DeliveryReport<Null, string>> handler = handler_ =>
  Console.WriteLine(handler_.Error.IsError ? "Delivery error - " + handler_.Error.Reason : "Message delivered to - " + handler_.TopicPartitionOffset);

using (var p = new ProducerBuilder<Null, string>(config).Build())
{

  try
  {
    for (int i = 0; i < 98; i++)
    {
      // var newMsg = await p.ProduceAsync("sample-topic", new Message<Null, string> { Value = "test" });
      // var newMsg =
      p.Produce("sample-topic", new Message<Null, string> { Value = "Sending this msg # " + i.ToString() }, handler);
    }

    // Console.WriteLine($"Delivered '{newMsg.Value}' to '{newMsg.TopicPartitionOffset}'");
  }
  catch (ProduceException<Null, string> ex)
  {
    Console.WriteLine("Deliver failed - " + ex.Error.Reason);
  }
}

