using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ItemService.NotificationHandler
{
    internal class MessageHandler
    {
        private static IModel _channel;
        private static EventingBasicConsumer _consumer = new EventingBasicConsumer(_channel);
        private static IConnection connection;

        static MessageHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            //Chk this
            _channel.QueueDeclare(queue: "CatalogQue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            
            _channel.ExchangeDeclare(exchange: "Exchange_APIManagement", type: ExchangeType.Fanout);

            Publish("Catalog MB Started.... Step:1");

        }

        public static bool Init()
        {
            return _channel != null;
        }

        public static void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "Exchange_APIManagement", routingKey: "", basicProperties: null, body: body);
        }


    }
}
