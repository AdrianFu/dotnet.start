using System;

namespace Core.API.MiddleWare
{
    public class MyScopedService : IMyScopedService
    {
        public DateTime ReceiveTime {get;set;}
        public string Author {get;set;}
    }

}