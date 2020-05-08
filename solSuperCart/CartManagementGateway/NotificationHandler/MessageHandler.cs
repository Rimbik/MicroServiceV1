using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CartManagementGateway.NotificationHandler
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

          //  var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: "CatalogQue", exchange: "Exchange_APIManagement", routingKey: "");


            _consumer.Received += Message_Received;
            
            _channel.BasicConsume(queue: "CatalogQue", autoAck: true, consumer: _consumer);
        }

        public static bool Init()
        {
            //
            return _channel != null;
        }

        private static void Message_Received(object sender, BasicDeliverEventArgs e)
        {
            byte[] body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            
            //Add in EventSourcing
            EventSourcing.EventHandler.Events.Add(new EventSourcing.Event()
            {
                Id = 1,
                Type = EventSourcing.EventType.ItemBlocked,
                ReferenceId = int.Parse(message.Split(',')[0]),
                OccuredAt = DateTime.Now
            }
            );
        }

        public static void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "Exchange_APIManagement", routingKey: "", basicProperties: null, body: body);
        }

        
    }
}
