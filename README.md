# Kafka Producer Consumer
This repo consists of the Kafka producer and the consumer.

### Setup Kafka

```
// Download and extract Kafka
wget https://dlcdn.apache.org/kafka/3.6.1/kafka_2.13-3.6.1.tgz
tar -xvf kafka*
cd kafka*

// Start zoo keeper
bin/zookeeper-server-start.sh config/zookeeper.properties

// Start Kafka broker service
bin/kafka-server-start.sh config/server.properties

// Create topic - one time
bin/kafka-topics.sh --create --topic sample-topic --bootstrap-server localhost:9092

```
### Consumer
Expected to consume about 100 mesaages from the producer.

```
cd cons
dotnet run
```

### Producer
Produces messages about 100 for the consumer to consume.
```
cd prod
dotnet run
```
