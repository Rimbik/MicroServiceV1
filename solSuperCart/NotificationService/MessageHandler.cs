using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace NotificationService
{
    public class MessageHandler
    {
        private static IModel _channel;
        private static EventingBasicConsumer _consumer = new EventingBasicConsumer(_channel);
        

        static MessageHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                _channel = connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "Exchange_APIManagement", type: ExchangeType.Fanout);
            }

            //
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: "Exchange_APIManagement", routingKey: "");

            _consumer.Received += Message_Received;
        }

        private static void Message_Received(object sender, BasicDeliverEventArgs e)
        {
            byte[] body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
        }

        public static void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "Exchange_APIManagement", routingKey: "", basicProperties: null, body: body);
        }

        
    }
}
