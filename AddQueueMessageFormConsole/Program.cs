using System;
using CloudeStorageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount;
using Microsoft.WindowsAzure.Storage.Queue;


namespace AddQueueMessageFormConsole
{
    class Program
    {
        public static string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=akstaccount;AccountKey=gkGSx+sQsRaUtEU9YAl5cxogSchyKpV7qHl8pkJ+rhuA+yiwllI+0C249yF7cRTu6JrAGX5Dr3Uo8i7rGjQqbA==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            AddMessage();
            Console.ReadKey();
        }

        public static void AddMessage()
        
        {
            Console.WriteLine("Write Some message for add in Queue -");
            string msg = Console.ReadLine();            
            CloudeStorageAccount cls = CloudeStorageAccount.Parse(ConnectionString);
            CloudQueueClient queueClient = cls.CreateCloudQueueClient();
            CloudQueue cloudQueue = queueClient.GetQueueReference("task-1");
            CloudQueueMessage queueMessage = new CloudQueueMessage(msg);
            if (queueMessage.AsString.Length > 0)
            {
                cloudQueue.AddMessage(queueMessage);
                Console.WriteLine("Message Add Successfully!!");
            }
            else
            {
                Console.WriteLine("Please write some messgae for add in Queue !");
                Console.Beep(500, 500);
            }            
        }
    }
}
