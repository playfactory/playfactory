using System;

namespace PlayFactory.Events.Bus.Factories.Internals
{
    internal class PreRegisterHandler
    {
        public Type EventType { get; set; }
        public Type HandlerType { get; set; }
    }
}
