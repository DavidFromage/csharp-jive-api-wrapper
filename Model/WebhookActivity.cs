using System;

namespace CheezeIT.JiveAPI.Model
{
    public class WebhookActivity
    {
        public int WebhookActivityId { get; set; }
        public Webhook Webhook { get; set; }
        public string ObjectUrl { get; set; }
        public string PlaceUrl { get; set; }
        public string ActorUrl { get; set; }
        public string Verb { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
