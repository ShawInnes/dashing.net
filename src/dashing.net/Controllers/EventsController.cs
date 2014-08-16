﻿namespace dashing.net.Controllers
{
    using dashing.net.common;
    using dashing.net.Infrastructure;
    using dashing.net.streaming;
    using Microsoft.AspNet.SignalR;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    public class EventsController : Hub
    {
        private static readonly BlockingCollection<string> MessageQueue = new BlockingCollection<string>();

        private static bool hasInstantiated;

        public void Send()
        {
            if (hasInstantiated == false)
            {
                LoadJobs();
            }
        }

        public override Task OnConnected()
        {
            if (hasInstantiated == false)
            {
                LoadJobs();

                hasInstantiated = true;
            }

            return base.OnConnected();
        }

        private void SendMessage(dynamic message)
        {
            var updatedAt = TimeHelper.ElapsedTimeSinceEpoch();

            if (message.GetType() == typeof(JObject))
            {
                message.updatedAt = updatedAt;
            }
            else
            {
                message = JsonHelper.Merge(message, new { updatedAt });
            }

            var serialized = JsonConvert.SerializeObject(message);

            MessageQueue.TryAdd(serialized);
        }

        private void ProcessQueue()
        {
            foreach (var message in MessageQueue.GetConsumingEnumerable())
            {
                Clients.All.sendMessage(message);
            }
        }

        private void LoadJobs()
        {
            Dashing.SendMessage = SendMessage;

            Task.Factory.StartNew(ProcessQueue);

            Jobs.Start();
        }
    }
}
