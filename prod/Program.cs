using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "localhost:9002" };

Action<DeliveryReport<Null, string>> handler = handler_ =>
  Console.WriteLine(handler_.Error.IsError ? "Delivery error - " + handler_.Error.Reason : "Message delivered to - " + handler_.TopicPartitionOffset);

using (var p = new ProducerBuilder<Null, string>(config).Build())
{

  try
  {
    // p.Flush();

    // for (int i = 0; i < 98; i++)
    // {
    //  p.Produce("sample-topic", new Message<Null, string> { Value = "Sending this msg # " + i.ToString() }, handler);
    // }

    var newMsg = await p.ProduceAsync("sample-topic", new Message<Null, string> { Value = "Message single" });
    Console.WriteLine($"Delivered '{newMsg.Value}' to '{newMsg.TopicPartitionOffset}'");
  }
  catch (ProduceException<Null, string> ex)
  {
    Console.WriteLine("Deliver failed - " + ex.Error.Reason);
  }
}

